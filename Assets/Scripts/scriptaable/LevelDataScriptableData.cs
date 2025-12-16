using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataScriptableData", menuName = "ScriptableObjects/LevelDataScriptableData")]
public class LevelDataScriptableData : ScriptableObject
{
    public int level_id;
    // zeby nie mylic z opisem na scenie keyboarda, to jest opis w menu lekcji
    [SerializeField] private string level_name;
    [SerializeField] private string level_desc;
    [SerializeField] private float tempo;
    [SerializeField] private int tact;


    // usunac serializacje
    [SerializeField] private int tile_count;
    [SerializeField] private float best_score;

    public string GetLevelName() { return level_name;}
    public string GetDescName() { return level_desc;}
    public float GetLevelTempo() { return tempo;}
    public int GetLevelTact() {return tact;}
    public int GetTileCount() {return tile_count;}
    public float GetBestScore() { return best_score;}
    public void SetBestScore(float x) {best_score = x;}

}
