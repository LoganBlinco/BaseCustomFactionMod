using Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements;
using Assets.BaseCustomFactionMod.Scripts.UiReplacement.PanelObjects;
using HoldfastSharedMethods;

namespace BaseCustomFactions.Core
{
    public static class CreatePanelReplacementFactory
    {
        public static RoundEndObjects CreateRoundEndPanelSettings(UiElementRepository repository)
        {
            //TextMeshProUGUI roundEnReasondText = GetRefenceFactory.GetRoundEndReasonText("Round End Reason Text");

            //defo refactor this at some point. Horrible.
            return new RoundEndObjects(repository.text_endPopupFactionEmblem, repository.text_endPopupFactionText, repository.text_endPopUpEndRoundReasonText,
                repository.image_endPanelAttackingEmblem, repository.image_endPanelAttackingBackground, repository.text_endPanelAttackingFactionName,
				repository.image_endPanelDefendingEmblem, repository.image_endPanelDefendingBackground, repository.text_endPanelDefendingFactionName);
        }
        
        public static SpawnMenuObjects CreateSpawnMenuObjects(UiElementRepository repository,
            FactionCountry attackingFaction, FactionCountry defendingFaction)
        {
            return new SpawnMenuObjects(repository.image_spawnMenuFactionEmblem, repository.text_spawnMenuFactionName,
                attackingFaction, defendingFaction, repository.gameobject_spawnMenuFlag);
        }



		public static ScoreBoardObjects CreateScoreBoardPanelSettings(UiElementRepository repository)
        {
            return new ScoreBoardObjects(repository.image_scoreboardAttackingEmblem,
                repository.image_scoreboardDefendingEmblem);
        }
        
        public static SpawnFactionObjects CreateFactionPanelSettings(UiElementRepository uiRepository,
            FactionCountry attackingFaction, FactionCountry defendingFaction)
        {
            return new SpawnFactionObjects(
                uiRepository.image_factionSelection_attackingEmblem,
                uiRepository.image_factionSelection_attackingEmblemDisabled,
                uiRepository.image_factionSelection_defendingEmblem,
                uiRepository.image_factionSelection_defendingEmblemDisabled,
                uiRepository.image_factionSelection_defendingBackground,
                uiRepository.image_factionSelection_attackingBackground,
                attackingFaction,
                defendingFaction);

        }

        public static TopBarObjects CreateTopBarPanelSettings(UiElementRepository repository)
        {
			return new TopBarObjects(repository.image_topBarAllyFlag,
                repository.image_topBarEnemyFlag);            
        }

        public static MapVotingObjects CreateMapVotingPanelSettings(UiElementRepository repository)
        {
            MapVotingObjects objects = new MapVotingObjects(repository.MapVotingCards.ToArray());
            return objects;
        }
    }
}