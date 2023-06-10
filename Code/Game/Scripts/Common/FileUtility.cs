using UnityEngine;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.Networking;

namespace Game
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class OpenFileName
    {
        public int structSize = 0;
        public IntPtr dlgOwner = IntPtr.Zero;
        public IntPtr instance = IntPtr.Zero;
        public String filter = null;
        public String customFilter = null;
        public int maxCustFilter = 0;
        public int filterIndex = 0;
        public String file = null;
        public int maxFile = 0;
        public String fileTitle = null;
        public int maxFileTitle = 0;
        public String initialDir = null;
        public String title = null;
        public int flags = 0;
        public short fileOffset = 0;
        public short fileExtension = 0;
        public String defExt = null;
        public IntPtr custData = IntPtr.Zero;
        public IntPtr hook = IntPtr.Zero;
        public String templateName = null;
        public IntPtr reservedPtr = IntPtr.Zero;
        public int reservedInt = 0;
        public int flagsEx = 0;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class OpenDialogDir
    {
        public IntPtr hwndOwner = IntPtr.Zero;
        public IntPtr pidlRoot = IntPtr.Zero;
        public String pszDisplayName = null;
        public String lpszTitle = null;
        public UInt32 ulFlags = 0;
        public IntPtr lpfn = IntPtr.Zero;
        public IntPtr lParam = IntPtr.Zero;
        public int iImage = 0;
    }

    public static class FileUtility
    {
        public static bool CheckFileExist(string strPath)
        {
            if (string.IsNullOrEmpty(strPath))
            {
                return false;
            }

            //安卓平台暂无存在判断
            if (Application.platform != RuntimePlatform.Android)
            {
                return File.Exists(strPath);
            }
            return true;
        }

        public static string GetFileText(string strPath)
        {
            string str = null;
            if (Application.platform == RuntimePlatform.Android)
            {
                UnityWebRequest request = UnityWebRequest.Get(strPath);
                while (!request.isDone) { }
                if (request.error == null)
                {
                    str = request.downloadHandler.text;
                }
                else
                {
                    Debug.LogError("GetFileText error, error = " + request.error + ", path = " + strPath);
                }
            }
            else
            {
                str = File.ReadAllText(strPath);
            }
            return str;
        }

        public static void CopyFile(string strPathFrom, string strPathTo)
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                UnityWebRequest request = UnityWebRequest.Get(strPathFrom);
                while (!request.isDone) { }
                if (request.error == null)
                {
                    File.WriteAllBytes(strPathTo, request.downloadHandler.data);
                }
                else
                {
                    Debug.LogError("CopyFile error, error = " + request.error + ", path_from = " + strPathFrom);
                    return;
                }
            }
            else
            {
                File.Copy(strPathFrom, strPathTo, true);
            }
        }

        public static string GetStreamingAssetsPath(string strPath)
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                return Application.streamingAssetsPath + strPath;
            }
            else
            {
                return "file://" + Application.streamingAssetsPath + strPath;
            }
        }

        //打开文件浏览器
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);

        [DllImport("shell32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SHBrowseForFolder([In, Out] OpenDialogDir odr);

        [DllImport("shell32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool SHGetPathFromIDList([In] IntPtr pidl, [In, Out] char[] fileName);

        //多选文件
        public static string[] OpenFileBrowse(string strTitle, string strFilter)
        {
            OpenFileName ofn = new OpenFileName();
            ofn.structSize = Marshal.SizeOf(ofn);
            ofn.filter = strFilter;
            ofn.file = new string(new char[1024]);
            ofn.maxFile = ofn.file.Length;
            ofn.fileTitle = new string(new char[64]);
            ofn.maxFileTitle = ofn.fileTitle.Length;
            ofn.initialDir = Application.dataPath;   //默认打开路径
            ofn.title = strTitle;
            //OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST|OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR  
            ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 /*| 0x00000200*/ | 0x00000008;

            if (GetOpenFileName(ofn))
            {
                ofn.file = ofn.file.Replace("\\", "/");
                string[] szSplit = {"\0"};
                string[] szStr = ofn.file.Split(szSplit, StringSplitOptions.RemoveEmptyEntries);
                return szStr;
            }
            return null;
        }

        public static string OpenSaveFolder()
        {
            OpenDialogDir odr = new OpenDialogDir();
            odr.pszDisplayName = new string(new char[1024]);
            odr.lpszTitle = "选择保存路径";
            IntPtr pidlPtr = SHBrowseForFolder(odr);

            char[] charArray = new char[1024];
            for (int i = 0; i < 1024; ++i)
            {
                charArray[i] = '\0';
            }

            if (SHGetPathFromIDList(pidlPtr, charArray))
            {
                string fullDirPath = new string(charArray);
                fullDirPath = fullDirPath.Substring(0, fullDirPath.IndexOf('\0'));
                return fullDirPath;
            }
            return null;
        }

        public static string GetFileMD5(string path)
        {
            byte[] md5Result;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5Result = md5.ComputeHash(fs);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Result.Length; i++)
            {
                sb.Append(md5Result[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
