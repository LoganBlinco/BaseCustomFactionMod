using System.Collections.Generic;
using Assets.Assets.BaseCustomFactions.HoldfastCustomFactions_main.Scripts.Config;
using HoldfastSharedMethods;

namespace BaseCustomFactions.Core
{
    public class CustomFactionSettingsManager
    {
        private readonly Dictionary<FactionCountry, FactionUIOverride> FactionToSettings;
        private readonly Dictionary<string, FactionUIOverride> _nameToFactionMap;
        private readonly Configuration _config;
		private readonly FactionCountry _defendingFaction;
		private readonly FactionCountry _attackingFaction;
        public CustomFactionSettingsManager(List<CustomFactionReplacementOverload.CustomFactionSettings> settings,
            Configuration config, FactionCountry defendingFaction, FactionCountry attackingFaction)
        {
			_config = config;
			_defendingFaction = defendingFaction;
			_attackingFaction = attackingFaction;

            FactionToSettings = new Dictionary<FactionCountry, FactionUIOverride>();
            _nameToFactionMap = new Dictionary<string, FactionUIOverride>();
            PopulateDictionary(settings);
        }
        private void PopulateDictionary(List<CustomFactionReplacementOverload.CustomFactionSettings> settings)
        {
            foreach (CustomFactionReplacementOverload.CustomFactionSettings workingFaction in settings)
            {
                FactionToSettings[workingFaction.FactionToOverride] = workingFaction.UIOverride;
                _nameToFactionMap[workingFaction.FactionIDName] = workingFaction.UIOverride;
            }
        }


        public FactionUIOverride GetSettingsOrNull(FactionCountry factionCountry)
		{
			if (_config.UseCustomOverride)
			{
				FactionUIOverride temp = GetSettingsForCustomSystem(factionCountry);
				if (temp != null)
				{
					return temp;
				}
			}
			return GetSettingForDefulatSystem(factionCountry);
		}

		private FactionUIOverride GetSettingForDefulatSystem(FactionCountry factionCountry)
		{
			if (FactionToSettings.TryGetValue(factionCountry,
					out FactionUIOverride settings))
			{
				return settings;
			}
			return null;
		}
		private FactionUIOverride GetSettingsForCustomSystem(FactionCountry factionCountry)
		{
			if (factionCountry == _attackingFaction)
			{
				if (_nameToFactionMap.TryGetValue(_config.AttackerFactionName, out FactionUIOverride settings))
				{
					return settings;
				}
			}
			if (factionCountry == _defendingFaction)
			{
				if (_nameToFactionMap.TryGetValue(_config.DefenderFactionName, out FactionUIOverride settings))
				{
					return settings;
				}
			}
			return null;
		}
	}
}