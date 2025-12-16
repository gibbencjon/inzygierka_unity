using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeScriptableData", menuName = "ScriptableObjects/VolumeScriptableData")]
public class VolumeScriptableData : ScriptableObject
{
    [SerializeField] private float master_volume;
    [SerializeField] private float metronome_volume;
    [SerializeField] private float piano_volume;

    public float GetMasterVolume()
    {
        return master_volume;
    }

    public float GetMetronomeVolume()
    {
        return metronome_volume;
    }

    public float GetPianoVolume()
    {
        return piano_volume;
    }

    public void SetMasterVolume(float x)
    {
        master_volume = x;
    }
    public void SetMetronomeVolume(float x)
    {
        metronome_volume = x;
    }

    public void SetPianoVolume(float x)
    {
        piano_volume = x;
    }
}
