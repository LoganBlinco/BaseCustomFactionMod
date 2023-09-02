using BaseCustomFactions;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements
{
	public class UiElementRepository
	{
		private GameObject MainCanvas;
		private GameObject MainScreenPanels;

		public Image image_factionSelection_attackingBackground;
		public Image image_factionSelection_attackingEmblem;
		public Image image_factionSelection_attackingEmblemDisabled;
		public Image image_factionSelection_defendingBackground;
		public Image image_factionSelection_defendingEmblem;
		public Image image_factionSelection_defendingEmblemDisabled;


		public Image image_topBarAllyFlag;
		public Image image_topBarEnemyFlag;


		public Image image_scoreboardAttackingEmblem;
		public Image image_scoreboardDefendingEmblem;

		public Image image_endPanelAttackingBackground;
		public Image image_endPanelAttackingEmblem;
		public TextMeshProUGUI text_endPanelAttackingFactionName;
		public Image image_endPanelDefendingBackground;
		public Image image_endPanelDefendingEmblem;
		public TextMeshProUGUI text_endPanelDefendingFactionName;

		public TextMeshProUGUI text_endPopupFactionText;
		public TextMeshProUGUI text_endPopUpEndRoundReasonText;
		public Image text_endPopupFactionEmblem;

		public List<MapVotingCard> MapVotingCards;

		public Image image_spawnMenuFactionEmblem;
		public TextMeshProUGUI text_spawnMenuFactionName;
		public GameObject gameobject_spawnMenuFlag;


		public UiElementRepository()
		{
			MainCanvas = GameObject.Find("Main Canvas");
			MainScreenPanels = GameObject.Find("Main Screen Panels");

			GetScoreboardElements();
			GetTopBarElements();
			GetFactionSelectionElements();
			GetRoundEndPanelElements();
			GetRoundEndPopUpElements();
			GetMapVotingElements();
			GetSpawnMenuElements();
		}

		private void GetSpawnMenuElements()
		{
			(image_spawnMenuFactionEmblem,
				text_spawnMenuFactionName) = SpawnMenuFinder.GetObjects(MainScreenPanels);

			gameobject_spawnMenuFlag = SpawnMenuCharacterSceneFinder.GetObjects();
		}


		private void GetMapVotingElements()
		{
			MapVotingCards = MapVotingPanelFinder.GetMapVotingCards(MainCanvas.transform);
		}

		private void GetRoundEndPopUpElements()
		{
			(text_endPopupFactionText,
			text_endPopupFactionEmblem,
			text_endPopUpEndRoundReasonText) = RoundEndPanelFinder.GetFactionWinPopup(MainCanvas);
		}


		private void GetRoundEndPanelElements()
		{
			(image_endPanelAttackingBackground,
			image_endPanelAttackingEmblem,
			text_endPanelAttackingFactionName,
			image_endPanelDefendingBackground,
			image_endPanelDefendingEmblem,
			text_endPanelDefendingFactionName) = RoundEndPanelFinder.GetElements(MainCanvas);
		}



		private void GetFactionSelectionElements()
		{
			(image_factionSelection_attackingEmblem,
				image_factionSelection_attackingEmblemDisabled,
				image_factionSelection_defendingEmblem,
				image_factionSelection_defendingEmblemDisabled,
				image_factionSelection_attackingBackground,
				image_factionSelection_defendingBackground)
				= FactionSelectionFinder.GetFactionSelectionImages(MainScreenPanels);
		}


		private void GetScoreboardElements()
		{
			(Image attacker, Image defender) = ScoreboardFinderFactory.GetEmblems();
			image_scoreboardAttackingEmblem = attacker;
			image_scoreboardDefendingEmblem = defender;
		}

		private void GetTopBarElements()
		{
			(Image ally, Image enemy) = TopBarElementsFinder.GetTopBarElments(MainCanvas);
			image_topBarAllyFlag = ally;
			image_topBarEnemyFlag = enemy;
		}




	}
}
