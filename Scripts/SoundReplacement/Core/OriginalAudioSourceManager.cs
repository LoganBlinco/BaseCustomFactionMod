using System.Collections.Generic;
using UnityEngine;

namespace BaseCustomFactions.SoundReplacement
{
    public class OriginalAudioSourceManager
    {
        private readonly List<AudioClip> _originalClips;
        private readonly List<AudioSource> _originalReferences;


        public OriginalAudioSourceManager(AudioSource[] audioSources)
        {
            _originalClips = new List<AudioClip>();
            _originalReferences = new List<AudioSource>();
            PopulateOriginalLists(audioSources);
        }
        
        private void PopulateOriginalLists(AudioSource[] audioSources)
        {
            foreach (AudioSource workingAudio in (audioSources))
            {
                _originalClips.Add(workingAudio.clip);
                _originalReferences.Add(workingAudio);
            }
        }

        public void RestoreAudioSources()
        {
            for (int index = 0; index < _originalReferences.Count; index++)
            {
                AudioSource workingReference = _originalReferences[index];
                if (workingReference != null)
                {
                    workingReference.clip = _originalClips[index];
                }
            }
        }
    }
}