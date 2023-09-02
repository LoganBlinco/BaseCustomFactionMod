using BaseCustomFactions.Core;
using BaseCustomFactions.Scripts.Logging;
using HoldfastSharedMethods;
using UnityEngine.UI;

namespace BaseCustomFactions
{
    public class MapVotingCard
    {
        private static readonly ILog Logger = LogFactory.GetLogger(typeof(MapVotingCard), LogLevelsEnum.Information);

        
        private readonly Image _attackingImage;
        private readonly Image _defendingImage;

        private bool _isValid;
        
        public MapVotingCard(Image attackingImage, Image defendingImage)
        {
            _attackingImage = attackingImage;
            _defendingImage = defendingImage;

            _isValid = _attackingImage != null && _defendingImage != null;
        }

        public void Replace(CustomFactionSettingsManager settingsManager)
        {
            string attackerName = _attackingImage.sprite.name;
            FactionCountry factionToReplace = GetFactionFromString.GetFactionBasedOnContainingName(attackerName);

            FactionUIOverride factionToUse = settingsManager.GetSettingsOrNull(factionToReplace);
            if (factionToUse != null)
            {
                _attackingImage.overrideSprite = factionToUse.mapVotingSprite;
            }

            string defendersName = _defendingImage.sprite.name;
            factionToReplace = GetFactionFromString.GetFactionBasedOnContainingName(defendersName);

            factionToUse = settingsManager.GetSettingsOrNull(factionToReplace);
            if (factionToUse != null)
            {
                _defendingImage.overrideSprite = factionToUse.mapVotingSprite;
            }

        }

		public void Destroy()
        {
            if (!_isValid){return;}
            _attackingImage.overrideSprite = null;
            _defendingImage.overrideSprite = null;
        }
    }
}