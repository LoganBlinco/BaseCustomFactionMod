using Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements;
using Assets.BaseCustomFactionMod.Scripts.UiReplacement.PanelObjects;
using HoldfastSharedMethods;
using UnityEngine;
using UnityEngine.Rendering;

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
            Sprite attackerFactionSprite = _attackerSettings != null ? _attackerSettings.factionEmblem : null;
            Sprite attackerFactionDisabledSprite = _attackerSettings != null ? _attackerSettings.factionEmblem : null;
            Sprite defenderFactionSprite = _defenderSettings != null ? _defenderSettings.factionEmblem : null;
            Sprite defenderFactionDisabledSprite = _defenderSettings != null ? _defenderSettings.factionEmblem : null;

            Sprite attackerFactionBcakground = _attackerSettings != null ? _attackerSettings.factionBackgroundSelection : null;
            Sprite defenderFactionBcackground = _defenderSettings != null ? _defenderSettings.factionBackgroundSelection : null;

            SpawnFactionObjects?.Replace(attackerFactionSprite, attackerFactionDisabledSprite, 
                defenderFactionSprite, defenderFactionDisabledSprite,
                attackerFactionBcakground, defenderFactionBcackground);
            
            Sprite attackersEmblem = _attackerSettings != null ? _attackerSettings.factionCrest : null;
            Sprite defendersEmblem = _defenderSettings != null ? _defenderSettings.factionCrest : null;



            SpawnMenuObjects?.SetUpReferences(_attackerSettings, _defenderSettings);            
            
        }
        public void ReplaceTopBar()
        {
            Sprite attackerTopSprite = _attackerSettings != null ? _attackerSettings.factionTopImage : null;
            Sprite defenderTopSprite = _defenderSettings != null ? _defenderSettings.factionTopImage : null;
            TopBarObjects?.Replace(attackerTopSprite, defenderTopSprite);
        }

        public void ReplaceScoreBoard()
        {
            Sprite attackerScoreboardSprite = _attackerSettings != null ? _attackerSettings.factionEmblem : null;
            Sprite defenderScoreboardSprite = _defenderSettings != null ? _defenderSettings.factionEmblem : null;

            ScoreBoardObjects?.Replace(attackerScoreboardSprite, defenderScoreboardSprite);
        }

        public void OnRoundEndFactionWinner(FactionCountry winningFaction)
        {
            string roundEndReason = string.Empty;
            if (winningFaction == AttackingFaction)
            {
                FactionUIOverride loserFaction = _customFactionSettingsManager.GetSettingsOrNull(DefendingFaction);
				if (loserFaction != null)
				    roundEndReason = $"The {loserFaction.customNameAdjective} troops in the battlefield have been eliminated.";
            }
            else if (winningFaction == DefendingFaction)
            {
                FactionUIOverride loserFaction = _customFactionSettingsManager.GetSettingsOrNull(AttackingFaction);
                if (loserFaction != null) 
                    roundEndReason = $"The {loserFaction.customNameAdjective} troops in the battlefield have been eliminated.";
            }
            _roundEndObjects = CreatePanelReplacementFactory.CreateRoundEndPanelSettings(uiRepositry);
            FactionUIOverride settings = _customFactionSettingsManager.GetSettingsOrNull(winningFaction);
            if (settings == null) { return; }
            _roundEndObjects.ReplaceRoundEndPopup(settings.factionEmblem, settings.customNameAdjective, roundEndReason);

            Sprite attackerEndOfRoundImage = _attackerSettings != null ? _attackerSettings.factionCrest : null;
            Sprite attackerBackground = _attackerSettings != null ? _attackerSettings.factionBackgroundSelection : null;
            string attackerCustomName = _attackerSettings != null ? _attackerSettings.customNameToUse : string.Empty;

            Sprite defenderEndOfRoundImage = _defenderSettings != null ? _defenderSettings.factionCrest : null;
            Sprite defenderBackground = _defenderSettings != null ? _defenderSettings.factionBackgroundSelection : null;
            string defenderCustomName = _defenderSettings != null ? _defenderSettings.customNameToUse : string.Empty;

			_roundEndObjects.ReplaceRoundEndPanel(attackerEndOfRoundImage, attackerBackground, attackerCustomName,
                defenderEndOfRoundImage, defenderBackground, defenderCustomName);
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
                playersSprite = _attackerSettings != null ? _attackerSettings.factionTopImage : null;
                otherSprite = _defenderSettings != null ? _defenderSettings.factionTopImage : null;
            }
            else if (factionCountry == DefendingFaction)
            {
                playersSprite = _defenderSettings != null ? _defenderSettings.factionTopImage : null;
                otherSprite = _attackerSettings != null ? _attackerSettings.factionTopImage : null;
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