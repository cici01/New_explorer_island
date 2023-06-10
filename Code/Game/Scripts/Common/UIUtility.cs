using UnityEngine;

namespace Game
{
    public static class UIUtility
    {
        public static void ShowWarning(int idStr, params object[] objs)
        {
            string str = LanguageHelper.get_client_str(idStr);
            str = string.Format(str, objs);
            WndWarning wndWarning = UIManager.Instance().OpenWindow<WndWarning>(EM_UIType.eUT_Warning);
            wndWarning.ShowText(str);
        }

        public static void ShowConfirm(string str, VoidFunc confirmFunc = null)
        {
            WndConfirm wndConfirm = UIManager.Instance().OpenWindow<WndConfirm>(EM_UIType.eUT_Confirm);
            wndConfirm.ShowConfirm(str, confirmFunc);
        }

        public static void ShowConfirmAndCancel(string str, VoidFunc confirmFunc = null, VoidFunc cancelFunc = null)
        {
            WndConfirm wndConfirm = UIManager.Instance().OpenWindow<WndConfirm>(EM_UIType.eUT_Confirm);
            wndConfirm.ShowConfirmAndCancel(str, confirmFunc, cancelFunc);
        }
    }
}
