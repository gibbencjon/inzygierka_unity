using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.Mathematics;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private VolumeScriptableData volume;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider MetronomeVolumeSlider;
    [SerializeField] private Slider PianoVolumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (volume)
        {
            // przy wczytywaniu sceny nie zczytuje danych ze slidera
            // dziala tylko wtedy gdy mam wglad w scriptable
            MasterVolumeSlider.value = volume.GetMasterVolume();
            MetronomeVolumeSlider.value = volume.GetMetronomeVolume();
            PianoVolumeSlider.value = volume.GetPianoVolume();
        }
    }

    
    // uzycie w przyciskach
    public void MasterVolumeUpdate() 
    {
        volume.SetMasterVolume(MasterVolumeSlider.value);
        mixer.SetFloat("Master", math.lerp(-80f, 0f, volume.GetMasterVolume()));
    
    }

    public void MetronomeVolumeUpdate() 
    {
        volume.SetMetronomeVolume(MetronomeVolumeSlider.value);
        mixer.SetFloat("Metronome", math.lerp(-80f, 0f, volume.GetMetronomeVolume()));
    }

    public void PianoVolumeUpdate() 
    {
        volume.SetPianoVolume(PianoVolumeSlider.value);
        mixer.SetFloat("Piano", math.lerp(-80f, 0f, volume.GetPianoVolume()));
    }
}
