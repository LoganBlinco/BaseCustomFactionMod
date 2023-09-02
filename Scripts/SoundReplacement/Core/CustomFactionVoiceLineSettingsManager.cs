using System.Collections.Generic;
using BaseCustomFactions.Core;
using BaseCustomFactions.SoundReplacement.FactionVoiceLineSounds;
using HoldfastSharedMethods;

namespace BaseCustomFactions.SoundReplacement
{
    public class CustomFactionVoiceLineSettingsManager
    {
        public Dictionary<FactionCountry, List<VoiceLineOverloadSetting>> FactionToVoiceLineSettings { get; }

        public CustomFactionVoiceLineSettingsManager(
            List<CustomFactionReplacementOverload.CustomFactionSettings> settings)
        {
            FactionToVoiceLineSettings = new Dictionary<FactionCountry, List<VoiceLineOverloadSetting>>();
            PopulateDictionary(settings);
        }

        private void PopulateDictionary(List<CustomFactionReplacementOverload.CustomFactionSettings> settings)
        {
            foreach (CustomFactionReplacementOverload.CustomFactionSettings workingSettings in settings)
            {
                FactionToVoiceLineSettings[workingSettings.FactionToOverride] = workingSettings.voiceLineSettings;
            }
        }
    }
}