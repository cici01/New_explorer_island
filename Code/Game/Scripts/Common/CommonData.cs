using UnityEngine;
using System.Collections;

namespace Game
{
    //对话框类型
    public enum EM_UIType
    {
        eUT_None,
        eUT_Confirm = 1,    //确定
        eUT_Warning = 2,    //警告
        eUT_Console = 3,    //控制台
        eUT_System  = 4,    //系统设置
        eUT_PM      = 5,    //pm命令
        eUT_Logo    = 6,    //logo
        eUT_Start   = 7,    //开始
        eUT_Loading = 8,    //进度条
        eUT_Background  = 9,    //背景
        eUT_Title   = 10,   //标题
        eUT_Modal   = 11,   //模式对话框
        eUT_Hero    = 12,   //英雄
        eUT_Shop    = 13,   //商店

        eUT_MapConsole  = 21,   //地图控制台
        eUT_MapTileInfo = 22,   //地图格子信息
        eUT_MapHeroInfo = 23,   //地图英雄信息
    }

    //对话框层级
    public enum EM_UILayer
    {
        eUL_LayerBottom,
        eUL_LayerNormal,
        eUL_LayerMiddle,
        eUL_LayerTop,
    }

    //通知消息
    public enum EM_NotifyMessage
    {
        eNM_None,
        eNM_LoadConfigComplete, //读配置完成
        eNM_LoadingProgress,    //进度条进度
    }

    public static class CommonData
    {
        public static Vector3 MAP_SCALE = new Vector3(0.4f, 0.4f, 1f);
        public static Vector2 TILE_SIZE = new Vector2(2.56f, 2.56f);
    }
}
