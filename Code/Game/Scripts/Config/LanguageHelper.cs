//自动生成此脚本
using UnityEngine;

namespace Game
{
	public static class LanguageHelper
	{
		public static string get_client_str(int nIndex)
		{
			int idStr = 10000 + nIndex;
			return ConfigManager.Instance().str.GetString(idStr);
		}

		public static string get_hero_name(int nIndex)
		{
			int idStr = 1010000 + nIndex;
			return ConfigManager.Instance().str.GetString(idStr);
		}

		public static string get_hero_description(int nIndex)
		{
			int idStr = 1020000 + nIndex;
			return ConfigManager.Instance().str.GetString(idStr);
		}

		public static string get_title_title(int nIndex)
		{
			int idStr = 2010000 + nIndex;
			return ConfigManager.Instance().str.GetString(idStr);
		}

		public static string get_enemy_name(int nIndex)
		{
			int idStr = 3010000 + nIndex;
			return ConfigManager.Instance().str.GetString(idStr);
		}

		public static string get_enemy_description(int nIndex)
		{
			int idStr = 3020000 + nIndex;
			return ConfigManager.Instance().str.GetString(idStr);
		}
	}
}
