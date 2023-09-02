using System.Collections.Generic;
using BaseCustomFactions.Core;
using BaseCustomFactions.SoundReplacement.FactionVoiceLineSounds;
using BaseCustomFactions.SoundReplacement.PrimarySounds;
using HoldfastSharedMethods;
using UnityEngine;

namespace BaseCustomFactions.SoundReplacement
{
    public class SoundReplacementManager
    {
        public static readonly string[] AUDIO_NAMES = new string[]
        {
            "flintlock_", "musket_reload_14seconds", "pistol_", "musket_reload_6seconds", "cannon_fire_", "ram_shot_",
            "swivel_fire", "0022_explosion", "blade_hit_blade_normalhit", "blade_hit_blade_heavyhit", "sword_swing",
            "axe_swing", "musket_swing", "blade_hit_flesh", "blunt_hit_flesh", "axe_hit_flesh", "pain_", "grunt_",
            "blade_hit_metal", "blade_hit_earth", "blade_hit_wood", "axe_hit_wood", "blade_hit_stone", "axe_hit_stone"
        };
        
        private readonly OriginalAudioSourceManager _originalAudioSourceManager;
        private readonly CustomFactionVoiceLineSettingsManager _customFactionVoiceLineSettingsManager;
        private readonly List<GlobalSoundOverloadSetting> _globalSoundOverloadSettings;
        
        public SoundReplacementManager(List<CustomFactionReplacementOverload.CustomFactionSettings> customFactionSettings, List<GlobalSoundOverloadSetting> globalSoundOverloadSettings)
        {
            AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>(true);

            _originalAudioSourceManager = new OriginalAudioSourceManager(audioSources);
            _customFactionVoiceLineSettingsManager = new CustomFactionVoiceLineSettingsManager(customFactionSettings);
            _globalSoundOverloadSettings = globalSoundOverloadSettings;
            
            ReplaceGlobalSounds(audioSources);

        }

        private void ReplaceGlobalSounds(AudioSource[] audioSources)
        {
            foreach (AudioSource workingSource in audioSources)
            {
                GlobalSoundReplacer.ReplaceSound(workingSource, _globalSoundOverloadSettings);
                ReplaceVoiceLines(workingSource);
            }
        }

        private void ReplaceVoiceLines(AudioSource workingSource)
        {
            foreach (KeyValuePair<FactionCountry, List<VoiceLineOverloadSetting>> voiceLine in
                     _customFactionVoiceLineSettingsManager.FactionToVoiceLineSettings)
            {
                VoiceLineReplacer.Replace(workingSource, voiceLine.Value, voiceLine.Key);
            }
        }

        public void RestoreSounds()
        {
            _originalAudioSourceManager?.RestoreAudioSources();
        }
    }
}