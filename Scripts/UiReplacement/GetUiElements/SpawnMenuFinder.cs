using BaseCustomFactions.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements
{
	public static class SpawnMenuFinder
	{
		public static (Image factionEmblem, TextMeshProUGUI factionText) GetObjects(GameObject MainScreenPanels)
		{
			Transform spawnMenuPanel = MainScreenPanels.transform.GetChild("Spawn Menu Panel");
			Transform newSpawnPanel = spawnMenuPanel.GetChild("New Spawn Panel");

			Transform header = newSpawnPanel.GetChild("Header");
			Transform emblem = header.GetChild("Emblem");
			Transform factionText = header.GetChild("Selected Faction Text");

			Image emblemImage = emblem.GetComponent<Image>();
			TextMeshProUGUI text = factionText.GetComponent<TextMeshProUGUI>();

			return (emblemImage, text);
		}
	}
}
