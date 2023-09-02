using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Assets.BaseCustomFactions.HoldfastCustomFactions_main.Scripts.Config
{
	public static class ConfigVariableManager
	{
		public const string MOD_NAME = "custom_factions";
		private static Configuration _config;

		private static Dictionary<string, Func<string[], bool>> _commadMap = new Dictionary<string, Func<string[], bool>>()
		{
			{"UseCustomFactions", variable_UseCustomFactions },
			{"CustomAttackerFactionID", variable_CustomAttackerFactionID },
			{"CustomDefenderFactionID", variable_CustomDefenderFactionID },
		};
		private static bool variable_CustomDefenderFactionID(string[] arg)
		{
			_config.DefenderFactionName = arg[2];
			return true;
		}

		private static bool variable_CustomAttackerFactionID(string[] arg)
		{
			_config.AttackerFactionName = arg[2];
			return true;
		}

		private static bool variable_UseCustomFactions(string[] arg)
		{
			if (bool.TryParse(arg[2], out bool result))
			{
				_config.UseCustomOverride = result;
				return true;
			}
			return false;
		}
		public static void PassConfigVariables(string[] value, Configuration config)
		{
			_config = config;
			char[] separator = { ':' };
			for (int i = 0; i < value.Length; i++)
			{
				var splitData = value[i].Split(separator, 3);
				if (splitData.Length != 3)
				{
					Debug.LogError("invalid number of variables");
					continue;
				}
				if (splitData[0] == MOD_NAME)
				{
					Func<string[], bool> function;
					if (_commadMap.TryGetValue(splitData[1], out function))
					{
						bool result = function(splitData);
						if (splitData[1].Contains("Password")) { continue; }
						Debug.Log($"Trying to change {splitData[1]} to value {splitData[2]}. Success? {result}");
					}
				}
			}
		}
	}
}
