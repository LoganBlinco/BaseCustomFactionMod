using BaseCustomFactions.Scripts.Logging;
using System.Collections.Generic;
using UnityEngine;

namespace BaseCustomFactions.SoundReplacement.PrimarySounds
{
    public static class GlobalSoundReplacer
    {
        private static readonly ILog Logger = LogFactory.GetLogger(typeof(GlobalSoundReplacer), LogLevelsEnum.Information);

        public static void ReplaceSound(AudioSource targetSource, List<GlobalSoundOverloadSetting> soundOverloads)
        {
            if (targetSource == null || targetSource.clip == null){return;}
            string sourceName = targetSource.clip.name;
            foreach (GlobalSoundOverloadSetting workingOverload in soundOverloads)
            {
                int intSelectedCore = (int) workingOverload.soundToReplace;
                for (int currentEnumToCheck = 0; currentEnumToCheck <= 19; currentEnumToCheck++)
                {
                    if (intSelectedCore != currentEnumToCheck) continue;
                    if (sourceName.Contains(SoundReplacementManager.AUDIO_NAMES[currentEnumToCheck]))
                    {
                        targetSource.clip = workingOverload.replacementSound;
                        if (workingOverload.replacementSound != null)
                        {
                           Logger.LogInformation($"Changed sound {sourceName} to {workingOverload.replacementSound.name}");
                        }
                    }
                }

                //Checks a few special cases. Not really sure what Dav's script is checking but will just refactor this. 
                switch (intSelectedCore)
                {
                    case 20:
                    {
                        if (sourceName.Contains(SoundReplacementManager.AUDIO_NAMES[20]) || sourceName.Contains(SoundReplacementManager.AUDIO_NAMES[21]))
                        {
                            targetSource.clip = workingOverload.replacementSound;
                        }
                        break;
                    }
                    case 21:
                    {
                        if (sourceName.Contains(SoundReplacementManager.AUDIO_NAMES[22]) || sourceName.Contains(SoundReplacementManager.AUDIO_NAMES[23]))
                        {
                            targetSource.clip = workingOverload.replacementSound;
                        
                        }
                        break;
                    }
                } 
            }
        }
    }
}