using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BaseCustomFactions
{
    public class ScoreBoardObjects
    {
        private readonly Image _attackingImage;
        private readonly Image _defendingImage;
        private bool _isValid;

        public ScoreBoardObjects(Image attackingImage, Image defendingImage)
        {
            _attackingImage = attackingImage;
            _defendingImage = defendingImage;
            _isValid = _attackingImage != null && _defendingImage != null;
        }

        public void Replace(Sprite attackerImage, Sprite defenderImage)
        {
            if (_attackingImage != null && attackerImage != null)
            {
                _attackingImage.overrideSprite = attackerImage;
            }

            if (_defendingImage != null && defenderImage != null)
            {
                _defendingImage.overrideSprite = defenderImage;
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