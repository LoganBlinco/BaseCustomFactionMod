using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BaseCustomFactions
{
    public class RoundEndObjects
    {
        private readonly Image _winningFactionEmblem;
        private readonly TextMeshProUGUI _winningFactionText;
        private readonly TextMeshProUGUI _roundEndReasonText;

        //could refactor into its own class.
        private readonly Image _leftFactionImage;
        private readonly Image _leftBackgroundFlag;
        private readonly TextMeshProUGUI _leftFactionName;
        
        private readonly Image _rightFactionImage;
        private readonly Image _rightBackgroundFlag;
        private readonly TextMeshProUGUI _rightFactionName;

        private bool _isValid;
        public RoundEndObjects(Image winningFactionEmblem, TextMeshProUGUI winningFactionText, TextMeshProUGUI roundEndReasonText, Image leftFactionImage, Image leftBackgroundFlag, TextMeshProUGUI leftFactionName, Image rightFactionImage, Image rightBackgroundFlag, TextMeshProUGUI rightFactionName)
        {
            _winningFactionEmblem = winningFactionEmblem;
            _winningFactionText = winningFactionText;
            _roundEndReasonText = roundEndReasonText;
            _leftFactionImage = leftFactionImage;
            _leftBackgroundFlag = leftBackgroundFlag;
            _leftFactionName = leftFactionName;
            _rightFactionImage = rightFactionImage;
            _rightBackgroundFlag = rightBackgroundFlag;
            _rightFactionName = rightFactionName;
        }

        public void ReplaceRoundEndPopup(Sprite winningFactionSprite, string winningFactionAdjective, string roundEndReason)
        {
            if (winningFactionSprite != null && _winningFactionEmblem != null)
            {
                _winningFactionEmblem.overrideSprite = winningFactionSprite;
            }

            if (winningFactionAdjective != string.Empty && _winningFactionText != null)
            {
                _winningFactionText.text = $"The {winningFactionAdjective} Are Victorious";
            }

            if (roundEndReason != string.Empty && _roundEndReasonText != null)
            {
                _roundEndReasonText.text = roundEndReason;  
            }
        }

        public void ReplaceRoundEndPanel(Sprite attackingSprite, Sprite attackingBackgroundFlag,
            string attackingFactionName,
            Sprite defendingSprite, Sprite defendingBackgroundFlag, string defendingFactionName)
        {
            if (attackingSprite != null) { _leftFactionImage.overrideSprite = attackingSprite; }
            if (attackingBackgroundFlag != null) { _leftBackgroundFlag.overrideSprite = attackingBackgroundFlag; }
            if (attackingFactionName != string.Empty) { _leftFactionName.text = attackingFactionName; }
            
            if (defendingSprite != null) { _rightFactionImage.overrideSprite = defendingSprite; }
            if (defendingBackgroundFlag != null) { _rightBackgroundFlag.overrideSprite = defendingBackgroundFlag; }
            if (defendingFactionName != string.Empty) { _rightFactionName.text = defendingFactionName; }
        }

        public void Destroy()
        {
            if (!_isValid){return;}

            _leftFactionImage.overrideSprite = null;
            _leftBackgroundFlag.overrideSprite = null;
            _rightFactionImage.overrideSprite = null;
            _rightFactionImage.overrideSprite = null;
        }
    }
}