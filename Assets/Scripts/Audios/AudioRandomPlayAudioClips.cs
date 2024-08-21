using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    public List<AudioClip> audioStepsList;

    public List<AudioSource> audioSourcesStepsList;

    private int _index = 0;

    public void PlayRandomSteps() {
        if (_index >= audioSourcesStepsList.Count) {
            _index = 0;
        }

        var audioSource = audioSourcesStepsList[_index];

        audioSource.clip = audioStepsList[Random.Range(0, audioStepsList.Count)];
        audioSource.Play();
    }
}
