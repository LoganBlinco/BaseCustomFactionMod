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
			Transform spawnMenuPanel = MainScreenPanels.transform.GetChild(3);
			Transform newFactionSelectionPanel = spawnMenuPanel.transform.GetChild(0);

			Transform backgroundAttacking = newFactionSelectionPanel.transform.GetChild(2);
			Transform backgroundDefending = newFactionSelectionPanel.transform.GetChild(3);


			//attacker faction
			Transform attackingPanel = newFactionSelectionPanel.transform.GetChild(7);
			Transform attackerMainContainer = attackingPanel.transform.GetChild(0);
			Transform attackerEmblemImages = attackerMainContainer.GetChild(2);

			Transform attackerEmblemImageTransform = attackerEmblemImages.GetChild(1);
			Transform attackerEmblemImageDisabledTransform = attackerEmblemImages.GetChild(0);

			//defender faction
			Transform defendingPanel = newFactionSelectionPanel.transform.GetChild(8);
			Transform defendingMainContainer = defendingPanel.transform.GetChild(0);
			Transform defendingEmblemImages = defendingMainContainer.GetChild(2);

			Transform defendingEmblemImageTransform = defendingEmblemImages.GetChild(1);
			Transform defendingEmblemImageDisabledTransform = defendingEmblemImages.GetChild(0);

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
