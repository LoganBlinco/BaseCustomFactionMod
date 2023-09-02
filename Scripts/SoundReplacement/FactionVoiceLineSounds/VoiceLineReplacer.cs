using System.Collections.Generic;
using BaseCustomFactions.Scripts.Logging;
using HoldfastSharedMethods;
using UnityEngine;

namespace BaseCustomFactions.SoundReplacement.FactionVoiceLineSounds
{
    public class VoiceLineReplacer
    {
        private static readonly ILog Logger = LogFactory.GetLogger(typeof(VoiceLineReplacer), LogLevelsEnum.Information);


        public static readonly string[] VOICE_LINE_NAMES = new string[]
        {
            "cheer_", "compliment_", "duel_", "get_down_", "good_shot_", "help_", "insult_", "medic_", "mutiny_",
            "no_sir_", "cheer_", "retreat_", "salute_", "stand_ground_", "stay_calm_", "surrender_", "taunt_",
            "thanks_", "warcry_", "yes_sir_", "make_ready_", "fire_at_will_", "cease_fire_", "charge_", "fire_"
        };

        
        public static void Replace(AudioSource audioSource, List<VoiceLineOverloadSetting> replacementSettings,
            FactionCountry factionToApply)
        {
            if (audioSource == null || audioSource.clip == null){return;}
            string sourceName = audioSource.name;
            string parentName = audioSource.transform.parent.name;

            //Array of voiceline names


            //loop for voice sounds
            for (int index = 0; index < replacementSettings.Count; index++)
            {
                int intSelectedVoiceline = (int) replacementSettings[index].voiceLineToRepalce;

                //variable for faction name
                string selectedFaction = factionToApply.ToString();

                //Loop to run through enum 
                for (int p = 0; p <= 22; p++)
                {
                    if (intSelectedVoiceline != p) continue;
                    if (!sourceName.Contains(VOICE_LINE_NAMES[p])) continue;
                    if (!parentName.Contains(selectedFaction)) continue;
                    audioSource.clip = replacementSettings[index].replacementClip;
                    if (replacementSettings[index].replacementClip != null)
                    {
                        Logger.LogInformation($"Changed sound {parentName} to {replacementSettings[index].replacementClip.name}");
                    }
                }

                switch (intSelectedVoiceline)
                {
                    case 23:
                    {
                        if (sourceName.Contains(VOICE_LINE_NAMES[23]) && !sourceName.Contains("horse") &&
                            parentName.Contains(selectedFaction))
                        {
                            audioSource.clip = replacementSettings[index].replacementClip;
                        }

                        break;
                    }
                    case 24:
                    {
                        if (sourceName.Contains(VOICE_LINE_NAMES[24]) && !sourceName.Contains(VOICE_LINE_NAMES[21]) &&
                            !sourceName.Contains(VOICE_LINE_NAMES[22]) && parentName.Contains(selectedFaction))
                        {
                            audioSource.clip = replacementSettings[index].replacementClip;
                        }

                        break;
                    }
                }
            }
        }
    }
}