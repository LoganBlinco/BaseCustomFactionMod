using BaseCustomFactions.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements
{
	public static class FactionSelectionFinder
	{
		public static (Image attackerImage,
			Image attackerImageDisabled,
			Image defenderImage,
			Image defenderImageDisabled,
			Image attackingImageBackground, 
			Image defendingImageBackground) GetFactionSelectionImages(GameObject MainScreenPanels)
		{
			Transform spawnMenuPanel = MainScreenPanels.transform.GetChildWithNameContains("Spawn Menu Panel");
			Transform newFactionSelectionPanel = spawnMenuPanel.GetChildWithNameContains("New Faction Selection Panel");

			Transform backgroundAttacking = newFactionSelectionPanel.GetChildWithNameContains("Background Attacking Faction Overlay");
			Transform backgroundDefending = newFactionSelectionPanel.GetChildWithNameContains("Background Defending Faction Overlay");
			
			//attacker faction
			Transform attackingPanel = newFactionSelectionPanel.GetChildWithNameContains("Attacking - Spawn Faction Panel");
			Transform attackerMainContainer = attackingPanel.GetChildWithNameContains("Main Container");
			Transform attackerEmblemImages = attackerMainContainer.GetChildWithNameContains("Emblem Images");

			Transform attackerEmblemImageTransform = attackerEmblemImages.GetChildWithNameContains("Emblem Image");
			Transform attackerEmblemImageDisabledTransform = attackerEmblemImages.GetChildWithNameContains("Grayscaled Image");

			//defender faction
			Transform defendingPanel = newFactionSelectionPanel.GetChildWithNameContains("Defending - Spawn Faction Panel");
			Transform defendingMainContainer = defendingPanel.GetChildWithNameContains("Main Container");
			Transform defendingEmblemImages = defendingMainContainer.GetChildWithNameContains("Emblem Images");

			Transform defendingEmblemImageTransform = defendingEmblemImages.GetChildWithNameContains("Emblem Image");
			Transform defendingEmblemImageDisabledTransform = defendingEmblemImages.GetChildWithNameContains("Grayscaled Image");

			Image attackerImage = attackerEmblemImageTransform.GetComponent<Image>();
			Image attackerImageDisabled = attackerEmblemImageDisabledTransform.GetComponent<Image>();

			Image defenderImage = defendingEmblemImageTransform.GetComponent<Image>();
			Image defenderImageDisabled = defendingEmblemImageDisabledTransform.GetComponent<Image>();

			Image backgroundAttackingImage = backgroundAttacking.GetComponent<Image>();
			Image backgroundDefendingImage = backgroundDefending.GetComponent<Image>();

			return (attackerImage, attackerImageDisabled, defenderImage, defenderImageDisabled,
				backgroundAttackingImage, backgroundDefendingImage);
		}

	}

}
