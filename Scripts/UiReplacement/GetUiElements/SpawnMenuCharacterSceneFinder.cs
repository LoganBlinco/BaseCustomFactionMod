using BaseCustomFactions.Scripts.Logging;
using UnityEngine;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements
{
	public static class SpawnMenuCharacterSceneFinder
	{
		public static GameObject GetObjectsAlt()
		{
			ILog logger = LogFactory.GetLogger(typeof(SpawnMenuCharacterSceneFinder), LogLevelsEnum.All);

			Transform[] allObjects = GameObject.FindObjectsOfType<Transform>(true);
			GameObject SpawnMenuCharacterScreen = FindObjectByName(allObjects, "Spawn Menu Character Screen");
			if (SpawnMenuCharacterScreen == null)
			{
				logger.LogError($"spawn character screen is null");
				return null;
			}
			logger.Debug($"found menu character screen: {SpawnMenuCharacterScreen.name} has children: {SpawnMenuCharacterScreen.transform.childCount}");

			foreach(Transform obj in SpawnMenuCharacterScreen.transform)
			{
				logger.Debug($"child obj is: {obj.name}");
				var result = test(new Transform[] { obj }, "Faction Flag");
				if (result != null)
				{
					logger.Debug("WE FOUND ONE");
					return result.gameObject;
				}
			}
			return null;
		}


		public static GameObject GetObjects()
		{
			ILog logger = LogFactory.GetLogger(typeof(SpawnMenuCharacterSceneFinder), LogLevelsEnum.All);

			Transform[] allObjects = GameObject.FindObjectsOfType<Transform>(true);


			GameObject SpawnMenuCharacterScreen = FindObjectByName(allObjects, "Spawn Menu Character Screen");
			if (SpawnMenuCharacterScreen == null) 
			{
				logger.LogError($"spawn character screen is null");
				return null; 
			}
			logger.Debug($"found menu character screen: {SpawnMenuCharacterScreen.name}");

			Transform[] allSpawnMenuObjects = SpawnMenuCharacterScreen.GetComponentsInChildren<Transform>(true);
			logger.Debug($"all spawn objects: {allSpawnMenuObjects.Length}");
			Transform flag = test(allSpawnMenuObjects, "Faction Flag");
			if (flag == null)
			{
				logger.LogError($"Did not find a flag");
				return null;
			}
			logger.LogError($"Found flag called: {flag}");
			return flag.gameObject;
		}

		public static Transform test(Transform[] searchArray, string searchName)
		{
			ILog logger = LogFactory.GetLogger(typeof(SpawnMenuCharacterSceneFinder), LogLevelsEnum.All);
			logger.Debug($"searching for: {searchArray.Length} elements");
			foreach (Transform obj in searchArray)
			{
				logger.Debug($"checking obj: {obj.name}");
				if (obj.name.Contains(searchName))
				{
					logger.LogInformation($"WE FOUND IT: {obj.name}");
					return obj;
				}
			}
			return null;
		}



		private static GameObject FindObjectByName(Transform[] objectArray, string searchName)
		{
			foreach (Transform obj in objectArray)
			{
				if (obj.name == searchName)
				{
					return obj.gameObject;
				}
			}
			return null;
		}
	}
}
