using Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements;
using Assets.BaseCustomFactionMod.Scripts.UiReplacement.PanelObjects;
using HoldfastSharedMethods;
using UnityEngine;

namespace BaseCustomFactions.Core
{
    public class ReplaceElementManager
    {
        
        
        private readonly CustomFactionSettingsManager _customFactionSettingsManager;

        public ScoreBoardObjects ScoreBoardObjects { get; set; } = null;
        public TopBarObjects TopBarObjects { get; set; } = null;
        public SpawnFactionObjects SpawnFactionObjects { get; set; } = null;

        public SpawnMenuObjects SpawnMenuObjects = null; 

        private MapVotingObjects _mapVotingObjects;
        private RoundEndObjects _roundEndObjects;
        
        public FactionCountry AttackingFaction { get; }
        public FactionCountry DefendingFaction { get; }

        private FactionUIOverride _defenderSettings = null;
        private FactionUIOverride _attackerSettings = null;

        public UiElementRepository uiRepositry;

        public ReplaceElementManager(FactionCountry attackingFaction, FactionCountry defendingFaction, CustomFactionSettingsManager settingsManager)
        {
            _customFactionSettingsManager = settingsManager;
            
            AttackingFaction = attackingFaction;
            DefendingFaction = defendingFaction;

            _attackerSettings = settingsManager.GetSettingsOrNull(AttackingFaction);
            _defenderSettings = settingsManager.GetSettingsOrNull(DefendingFaction);
            
        }
        
        public void ReplaceFactionPanel()
        {
            Sprite attackerFactionSprite = _attackerSettings != null ? _attackerSettings.factionSelectionSprite : null;
            Sprite attackerFactionDisabledSprite = _attackerSettings != null ? _attackerSettings.factionSelectionDisabledSprite : null;
            Sprite defenderFactionSprite = _defenderSettings != null ? _defenderSettings.factionSelectionSprite : null;
            Sprite defenderFactionDisabledSprite = _defenderSettings != null ? _defenderSettings.factionSelectionDisabledSprite : null;

            SpawnFactionObjects?.Replace(attackerFactionSprite, attackerFactionDisabledSprite, defenderFactionSprite, defenderFactionDisabledSprite);
            
            Sprite attackersEmblem = _attackerSettings != null ? _attackerSettings.selectClassHeaderEmblem : null;
            Sprite defendersEmblem = _defenderSettings != null ? _defenderSettings.selectClassHeaderEmblem : null;



            SpawnMenuObjects?.SetUpReferences(_attackerSettings, _defenderSettings);            
            
        }
        public void ReplaceTopBar()
        {
            Sprite attackerTopSprite = _attackerSettings != null ? _attackerSettings.topBarSprite : null;
            Sprite defenderTopSprite = _defenderSettings != null ? _defenderSettings.topBarSprite : null;
            TopBarObjects?.Replace(attackerTopSprite, defenderTopSprite);
        }

        public void ReplaceScoreBoard()
        {
            Sprite attackerScoreboardSprite = _attackerSettings != null ? _attackerSettings.scoreboardSprite : null;
            Sprite defenderScoreboardSprite = _defenderSettings != null ? _defenderSettings.scoreboardSprite : null;

            ScoreBoardObjects?.Replace(attackerScoreboardSprite, defenderScoreboardSprite);
        }

        public void OnRoundEndFactionWinner(FactionCountry winningFaction)
        {
            string roundEndReason = string.Empty;
            if (winningFaction == AttackingFaction)
            {
                FactionUIOverride loserFaction = _customFactionSettingsManager.GetSettingsOrNull(DefendingFaction);
                roundEndReason = $"The {loserFaction.customNameAdjective} troops in the battlefield have been eliminated.";
            }
            else if (winningFaction == DefendingFaction)
            {
                FactionUIOverride loserFaction = _customFactionSettingsManager.GetSettingsOrNull(AttackingFaction);
                roundEndReason = $"The {loserFaction.customNameAdjective} troops in the battlefield have been eliminated.";
            }
            _roundEndObjects = CreatePanelReplacementFactory.CreateRoundEndPanelSettings(uiRepositry);
            FactionUIOverride settings = _customFactionSettingsManager.GetSettingsOrNull(winningFaction);
            _roundEndObjects.ReplaceRoundEndPopup(settings.factionSelectionSprite, settings.customNameAdjective, roundEndReason);

            _roundEndObjects.ReplaceRoundEndPanel(_attackerSettings.squareRoundEndBoardSprite, _attackerSettings.scoreboardSprite, _attackerSettings.customNameToUse,
                _defenderSettings.squareRoundEndBoardSprite, _defenderSettings.scoreboardSprite, _defenderSettings.customNameToUse);
            

        }

        public void MapVoting()
        {
            _mapVotingObjects = CreatePanelReplacementFactory.CreateMapVotingPanelSettings(uiRepositry);
            _mapVotingObjects.Replace(_customFactionSettingsManager);
        }
        public void PlayerSpawnedReplaceTopBarObjects(FactionCountry factionCountry)
        {
            //the "left / attacking" faction must be the players faction


            Sprite playersSprite = null;
            Sprite otherSprite = null;
            
            if (factionCountry == AttackingFaction)
            {
                playersSprite = _attackerSettings != null ? _attackerSettings.topBarSprite : null;
                otherSprite = _defenderSettings != null ? _defenderSettings.topBarSprite : null;
            }
            else if (factionCountry == DefendingFaction)
            {
                playersSprite = _defenderSettings != null ? _defenderSettings.topBarSprite : null;
                otherSprite = _attackerSettings != null ? _attackerSettings.topBarSprite : null;
            }
            TopBarObjects?.Replace(playersSprite, otherSprite);
        }

        public void OnDestroy()
        {
            _mapVotingObjects?.Destroy();
            _roundEndObjects?.Destroy();
            SpawnFactionObjects?.Destroy();
            TopBarObjects?.Destroy();
            ScoreBoardObjects?.Destroy();
        }


    }
}