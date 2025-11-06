using UnityEngine;
using UnityEngine.Audio;

public class Metronome_Controller : MonoBehaviour
{
    private AudioMixerSnapshot mutedSnapshot;
    private AudioMixerSnapshot unmutedSnapshot;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // PlayAllBackgroundNoises();
    }

    private GameObject[] GetAllTaggedAsAudioSources()
    {
        return GameObject.FindGameObjectsWithTag("metronome_sound");
    }

    private void Mute()
    {
        mutedSnapshot.TransitionTo(0);
    }
    
    private void Unmute()
    {
        unmutedSnapshot.TransitionTo(0);
    }


    private void PlayAllBackgroundNoises()
    {
        GameObject[] audioSourceObjects = GetAllTaggedAsAudioSources();
        foreach (GameObject audioSourceObject in audioSourceObjects)
        {
            if (audioSourceObject != null)
            {
                AudioSource source = audioSourceObject.GetComponent<AudioSource>();
                if (source != null)
                {
                    source.Play();
                }
            }
        }
    }

}
