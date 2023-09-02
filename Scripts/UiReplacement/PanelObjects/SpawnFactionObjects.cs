using HoldfastSharedMethods;
using UnityEngine;
using UnityEngine.UI;
using BaseCustomFactions.Scripts.Logging;
using BaseCustomFactions.Core;

namespace BaseCustomFactions
{
    public class SpawnFactionObjects
    {
        private static readonly ILog Logger = LogFactory.GetLogger(typeof(SpawnFactionObjects), LogLevelsEnum.All); 

        private readonly Image _attackersEmblemImage;
        private readonly Image _attackersEmblemImageDisabled;
        
        private readonly Image _defendersEmblemImage;
        private readonly Image _defendersEmblemImageDisabled;

        private readonly Image _attackerBackground;
        private readonly Image _defenderBackground;

        private FactionCountry _defendingFaction;
        private FactionCountry _attackingFaction;

        //private OnEnableCaller _caller;
        
        public bool IsValid { get; } = false;

        public SpawnFactionObjects(Image attackersEmblemImage, Image attackersEmblemImageDisabled, 
            Image defendersEmblemImage, Image defendersEmblemImageDisabled,
            Image defenderBackground, Image attackerBackground, 
            FactionCountry attackers, FactionCountry defenders)
        {
            _attackersEmblemImage = attackersEmblemImage;
            _attackersEmblemImageDisabled = attackersEmblemImageDisabled;
            _defendersEmblemImage = defendersEmblemImage;
            _defendersEmblemImageDisabled = defendersEmblemImageDisabled;
            _defenderBackground = defenderBackground;
            _attackerBackground = attackerBackground;
            _attackingFaction = attackers;
            _defendingFaction = defenders;
            
            IsValid = _attackersEmblemImage != null && _attackersEmblemImageDisabled != null &&
                       _defendersEmblemImage != null && _defendersEmblemImageDisabled != null;
        }
        
        public void Replace(Sprite attackerImage, Sprite attackerImageDisabled, Sprite defenderImage, Sprite defenderImageDisabled)
        {
            if (!IsValid){return;}
            
            if (attackerImage != null && attackerImageDisabled != null)
            {
                _attackersEmblemImage.overrideSprite = attackerImage;
                _attackersEmblemImageDisabled.overrideSprite = attackerImageDisabled;
            }
            if (defenderImage != null && defenderImageDisabled != null)
            {
                _defendersEmblemImage.overrideSprite = defenderImage;
                _defendersEmblemImageDisabled.overrideSprite = defenderImageDisabled;
            }
            if (_attackerBackground != null)
            {
                _attackerBackground.overrideSprite = attackerImage;
            }
            if (_defenderBackground != null)
            {
                _defenderBackground.overrideSprite = defenderImage;
            }
        }

        public void Destroy()
        {
            if (!IsValid){return;}

            _attackersEmblemImage.overrideSprite = null;
            _attackersEmblemImageDisabled.overrideSprite = null;
            _defendersEmblemImage.overrideSprite = null;
            _defendersEmblemImageDisabled.overrideSprite = null;
        }
    }
}