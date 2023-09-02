using UnityEngine;

namespace BaseCustomFactions.SoundReplacement.PrimarySounds
{
    [System.Serializable]
    public class GlobalSoundOverloadSetting
    {
        public GlobalSoundTypes soundToReplace = GlobalSoundTypes.Pain;
        public AudioClip replacementSound;
    }
}