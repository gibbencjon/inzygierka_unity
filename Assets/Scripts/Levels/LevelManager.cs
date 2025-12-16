// Skrypt jest podpiety do sceny wyboru levelu jako LevelManager

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private LevelDataScriptableData level_data;
    [SerializeField] private CurrentLevelScriptableData current_level_data;
    [SerializeField] private GameObject side_panel;
    [SerializeField] private TMP_Text level_name;
    [SerializeField] private TMP_Text level_desc;
    [SerializeField] private TMP_Text tile_count;
    

    private Beatmap_level beatmap_level;
    private List<object> level_to_load;
    [SerializeField] public List<LevelDataScriptableData> levels;
    

    void Start()
    {
        beatmap_level = GetComponent<Beatmap_level>();
        if (side_panel) {side_panel.SetActive(false);}
    }


    public void EnableLevelSelect(LevelDataScriptableData temp_level_data)
    {
        level_data = temp_level_data;
        if (!level_data)
        {
            level_name.text = "brak wykrytego poziomu";
            level_desc.text = "twórca zapomniał o tej ważnej implementacji, czekaj na najbliższego patcha";
            tile_count.text = "Tempo: nieznane, chyba szybkie \nIlość kafelków: chyba dużo, nie wiem nie grałem \nWynik: brak";
        }
        level_name.text = level_data.GetLevelName();
        level_desc.text = level_data.GetDescName();
        tile_count.text = "Tempo: " + level_data.GetLevelTempo() +
        "\nIlość kafelków: " + level_data.GetTileCount() +
        "\nWynik: " + level_data.GetBestScore() + "%";

        // pierw zaladuj tekst a potem aktywuj to wszystko
        side_panel.SetActive(true);
    }
    
    void SelectLevel()
    {
        // lista listy obiektow
        List<List<object>> all_levels = new List<List<object>>()
        {
            beatmap_level.level1,
            beatmap_level.level2,
            beatmap_level.level3,
            beatmap_level.undertale_ending,
        };
        for (int i = 0; i <= all_levels.Count; i++)
        {
            if (level_data.level_id == i)
            {
                level_to_load = all_levels[i];
                current_level_data.SetLeveLID(level_data.level_id);
                current_level_data.SetNextLevel(level_to_load);
                current_level_data.SetLevelBPM(level_data.GetLevelTempo());
                current_level_data.SetLevelTact(level_data.GetLevelTact());
            }
        }
    }

    public void LoadLevel()
    {
        SelectLevel();
        SceneManager.LoadScene(1);
    }
}
