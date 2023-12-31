﻿using BaseCustomFactions;
using System.Collections.Generic;
using BaseCustomFactions.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements
{
	public static class MapVotingPanelFinder
	{
		public static List<MapVotingCard> GetMapVotingCards(Transform MainCanvas)
		{
			Transform MapVotingPanel = MainCanvas.GetChild("Map Voting Panel");

			Transform canvasGroup = MapVotingPanel.GetChild("Canvas Group");
			Transform horizontalLayoutGroup = canvasGroup.GetChild("Horizontal Layout Group");
			Transform mapVotingCard1 = horizontalLayoutGroup.GetChild(0);
			Transform mapVotingCard2 = horizontalLayoutGroup.GetChild(1);
			Transform mapVotingCard3 = horizontalLayoutGroup.GetChild(2);

			List<MapVotingCard> final = new List<MapVotingCard>
			{
				GetMapVotingCardObjects(mapVotingCard1),
				GetMapVotingCardObjects(mapVotingCard2),
				GetMapVotingCardObjects(mapVotingCard3)
			};
			return final;
		}


		private static MapVotingCard GetMapVotingCardObjects(Transform mapVotingCard)
		{
			Transform attackingFactionIcon = mapVotingCard.GetChild("Attacker Faction");
			Transform defendingFactionIcon = mapVotingCard.GetChild("Defending Faction");

			Image attackingImage = attackingFactionIcon.GetComponent<Image>();
			Image defendingImage = defendingFactionIcon.GetComponent<Image>();

			return new MapVotingCard(attackingImage, defendingImage);
		}

	}
}
