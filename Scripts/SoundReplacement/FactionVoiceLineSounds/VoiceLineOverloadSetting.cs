using UnityEngine;

namespace BaseCustomFactions.SoundReplacement.FactionVoiceLineSounds
{
    [System.Serializable]
    public class VoiceLineOverloadSetting
    {
        [Tooltip("This voiceline will be replaced for the given faction")]
        public VoiceLineTypes voiceLineToRepalce;
        [Tooltip("Voice clip it will be replaced with")]
        public AudioClip replacementClip;
    }
}