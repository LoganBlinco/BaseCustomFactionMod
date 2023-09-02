using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements
{
	public static class SpawnMenuFinder
	{
		public static (Image factionEmblem, TextMeshProUGUI factionText) GetObjects(GameObject MainScreenPanels)
		{
			Transform spawnMenuPanel = MainScreenPanels.transform.GetChild(3);
			Transform newSpawnPanel = spawnMenuPanel.GetChild(1);

			Transform header = newSpawnPanel.GetChild(5);
			Transform emblem = header.GetChild(0);
			Transform factionText = header.GetChild(1);

			Image emblemImage = emblem.GetComponent<Image>();
			TextMeshProUGUI text = factionText.GetComponent<TextMeshProUGUI>();

			return (emblemImage, text);
		}
	}
}
