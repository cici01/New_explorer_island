using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Game
{
    public static class CommonUtility
    {
        //异步加载场景
        public static void LoadScene(string strName)
        {
            UIManager.Instance().OpenWindow(EM_UIType.eUT_Loading);
            GameMain.Instance().StartCoroutine(LoadSceneAsync(strName));
        }

        private static IEnumerator LoadSceneAsync(string strName)
        {
            int nProgressCur = 0;
            int nProgressTo = 200;
            AsyncOperation op = SceneManager.LoadSceneAsync(strName);
            op.allowSceneActivation = false;

            while (op.progress < 0.9f)
            {
                while (nProgressCur < nProgressTo)
                {
                    ++nProgressCur;
                    SetProgress((float)nProgressCur / nProgressTo);
                    yield return new WaitForEndOfFrame();
                }
                yield return new WaitForEndOfFrame();
            }
            op.allowSceneActivation = true;
        }

        private static void SetProgress(float fProgress)
        {
            object[] szObject = new object[1];
            szObject[0] = fProgress;
            NotifyCenter.Instance().Notify(EM_NotifyMessage.eNM_LoadingProgress, szObject);
        }
    }
}
