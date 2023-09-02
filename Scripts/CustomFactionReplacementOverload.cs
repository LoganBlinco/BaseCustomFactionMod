using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoldfastSharedMethods;
using UnityEngine;
using Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements;
using BaseCustomFactions.SoundReplacement;
using BaseCustomFactions.SoundReplacement.PrimarySounds;
using Assets.Assets.BaseCustomFactions.HoldfastCustomFactions_main.Scripts.Config;
using BaseCustomFactions.SoundReplacement.FactionVoiceLineSounds;

namespace BaseCustomFactions.Core
{
    public class CustomFactionReplacementOverload : MonoBehaviour
    {

        [Header("Custom Faction Setup")]
        public List<CustomFactionSettings> customFactions;
        [Header("Global sounds")]
        public List<GlobalSoundOverloadSetting> globalSoundsToReplace;
        

        
        private ReplaceElementManager _replaceElementManager;
        private SoundReplacementManager _soundReplacementManager;
        private FactionCountry _attackingFaction = FactionCountry.None;
        private FactionCountry _defendingFaction = FactionCountry.None;

        private UiElementRepository _uiElementRepository;

		private void Awake()
        {
            _soundReplacementManager = new SoundReplacementManager(customFactions, globalSoundsToReplace);
        }
        private void OnDestroy()
        {
            _soundReplacementManager?.RestoreSounds();
            _replaceElementManager?.OnDestroy();
        }
        
        public async void RoundDetailsAsync(FactionCountry attackingFaction,
            FactionCountry defendingFaction, Configuration config)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(150); //seems needed otherwise the things wont get made

            _attackingFaction = attackingFaction;
            _defendingFaction = defendingFaction;

			CustomFactionSettingsManager _customFactionSettingsManager = new CustomFactionSettingsManager(customFactions,
                config, defendingFaction, attackingFaction);


			_replaceElementManager =
                new ReplaceElementManager(_attackingFaction, _defendingFaction, _customFactionSettingsManager);
            
            await Task.Delay(ts);

			_uiElementRepository = new UiElementRepository();
            _replaceElementManager.uiRepositry = _uiElementRepository;

            _replaceElementManager.ScoreBoardObjects = CreatePanelReplacementFactory.CreateScoreBoardPanelSettings(_uiElementRepository);
            _replaceElementManager.TopBarObjects = CreatePanelReplacementFactory.CreateTopBarPanelSettings(_uiElementRepository);
            _replaceElementManager.SpawnFactionObjects = CreatePanelReplacementFactory.CreateFactionPanelSettings(_uiElementRepository, _attackingFaction, _defendingFaction);
            _replaceElementManager.SpawnMenuObjects = CreatePanelReplacementFactory.CreateSpawnMenuObjects(_uiElementRepository,
                attackingFaction, defendingFaction);

            _replaceElementManager.ReplaceScoreBoard();
            _replaceElementManager.ReplaceTopBar();
            _replaceElementManager.ReplaceFactionPanel();
        }
        
        public async void OnPlayerSpawnedAsync(FactionCountry factionCountry)
        {
            _replaceElementManager.PlayerSpawnedReplaceTopBarObjects(factionCountry);
        }
        public async void OnRoundEndFactionWinnerAsync(FactionCountry factionCountry, FactionRoundWinnerReason reason)
        {
            if (factionCountry == FactionCountry.None) { return;}
            
            TimeSpan ts = TimeSpan.FromMilliseconds(5); //seems needed otherwise the things wont get made
            await Task.Delay(ts);            
            _replaceElementManager.OnRoundEndFactionWinner(factionCountry);
            
            ts = TimeSpan.FromMilliseconds(18500); //seems needed otherwise the things wont get made
            await Task.Delay(ts);
            
            _replaceElementManager.MapVoting();
        }
        
        
        [System.Serializable]
        public class CustomFactionSettings
        {
            public string FactionIDName = "";

            [Tooltip("This is the faction which will be replaced ingame. Make sure not to override the same faction twice")]
            public FactionCountry FactionToOverride = FactionCountry.British;

            [Tooltip("UI settings which will be applied to the faction")]
            public FactionUIOverride UIOverride;
            
            [Tooltip("Voice lines which get replaced for this faction")]
            public List<VoiceLineOverloadSetting> voiceLineSettings;
        }
    }
}