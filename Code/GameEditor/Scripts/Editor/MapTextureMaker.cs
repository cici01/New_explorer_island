using Game;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameEditor
{
    public class MapTextureMaker
    {
        private static byte[,] s_szTestMap = new byte[10, 10] {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };

        [MenuItem("CommonTools/生成地图texture")]
        private static void MakeMapTexture()
        {
            int nWidth = s_szTestMap.GetLength(0);
            int nHeight = s_szTestMap.GetLength(1);
            Color32[] szColor = new Color32[s_szTestMap.Length];
            for (int i = nHeight - 1; i >= 0; --i)
            {
                for (int j = 0; j < nWidth; ++j)
                {
                    int n = (nHeight - 1 - i) * nWidth + j;
                    szColor[n] = new Color32(s_szTestMap[i, j], 0, 0, 255);
                }
            }

            Texture2D texture = new Texture2D(nWidth, nHeight);
            texture.SetPixels32(szColor);
            texture.Apply();

            string strPath = Application.dataPath + "/Arts/Textures/Dynamic/Map";
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }

            string strName = "Map1.png";
            strPath = strPath + "/" + strName;
            byte[] szByte = texture.EncodeToPNG();
            File.WriteAllBytes(strPath, szByte);
            AssetDatabase.Refresh();
            Debug.Log("Make map texture success >>>>" + strPath);

            int nIndex = strPath.IndexOf("Assets");
            if (nIndex == -1)
            {
                return;
            }

            strPath = strPath.Substring(nIndex);
            TextureImporter textureImporter = AssetImporter.GetAtPath(strPath) as TextureImporter;
            if (textureImporter != null)
            {
                textureImporter.isReadable = true;
                AssetDatabase.ImportAsset(strPath);
                AssetDatabase.Refresh();
            }
        }
    }
}
