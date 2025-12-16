using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentLevelScriptableData", menuName = "ScriptableObjects/CurrentLevelScriptableData")]
public class CurrentLevelScriptableData : ScriptableObject
{
    // prosty scriptable przechowujący dane bieżącego levelu
    [SerializeField] private List<object> next_level_to_load;
    [SerializeField] private float bpm;
    [SerializeField] private int tact;
    [SerializeField] private int id;


    public List<object> GetNextLevelToLoad() {return next_level_to_load;}
    public void SetNextLevel(List<object> x) {next_level_to_load = x;}

    public float GetLevelBPM() {return bpm;}
    public void SetLevelBPM(float x) {bpm = x;}

    public int GetLevelTact() {return tact;}
    public void SetLevelTact(int x) {tact = x;}

    public int GetLevelID() {return id;}
    public void SetLeveLID(int x) {id = x;}
}
