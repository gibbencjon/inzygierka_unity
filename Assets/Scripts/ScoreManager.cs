using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // score
    public string final_score;
    public int tiles_missed;
    public int tiles_hit_early;
    public int tiles_hit_perfect;
    public int tiles_hit_late;

    [SerializeField] private GameObject score_screen;
    [SerializeField] private TextMeshProUGUI final_score_text;
    [SerializeField] private CurrentLevelScriptableData current_level;
    LevelManager level_manager;

    void Start()
    {
        level_manager = GetComponent<LevelManager>();
    }
    

    private string CountScore()
    {   // wynik dzielenia obecnych trafionych kafelkow przez wszystkie przeleciane kafelki
        final_score = ((tiles_hit_perfect + (tiles_hit_early * 0.5f) + (tiles_hit_late * 0.5f)) 
        / (tiles_missed + tiles_hit_early + tiles_hit_perfect + tiles_hit_late)).ToString();

        return final_score != null ? "0" : final_score;
        // key_text.fontSize = isBlack ? 12 : 15;
    }
    public void UpdateScoreText()
    {
        final_score_text.text = "Wynik: " + CountScore() + 
        "\nKafelki uderzone za wcześnie: " + tiles_hit_early +
        "\nKafelki uderzone idealnie: " + tiles_hit_perfect +
        "\nKafelki uderzone za późno: " + tiles_hit_late +
        "\nKafelki ominięte: " + tiles_missed;
    }

    public void ActivateScoreScreen()
    {
        score_screen.SetActive(true);
        UpdateScoreText();
    }

    public void DeactivateScoreScreen()
    {
        score_screen.SetActive(false);
    }
    
    public void ExitAndSaveScore()
    {
        foreach (LevelDataScriptableData level in level_manager.levels)
        {
            Debug.Log(level.level_id);
            Debug.Log(current_level);
            if (level.level_id == current_level.GetLevelID())
            {
                level.SetBestScore(float.Parse(CountScore()));
            }
        }
        SceneManager.LoadScene(3);
    }
}
