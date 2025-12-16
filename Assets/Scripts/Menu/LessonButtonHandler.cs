using UnityEngine;

public class LessonButtonHandler : MonoBehaviour
{
    LevelManager level_manager;
    [SerializeField] private LevelDataScriptableData level_data;

    void Start()
    {
        level_manager = FindAnyObjectByType<LevelManager>();
    }

    public void SendLevelDataToLevelManager()
    {
        level_manager.EnableLevelSelect(level_data);
    }
}
