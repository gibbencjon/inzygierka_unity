using UnityEngine;


public class EscMenuController : MonoBehaviour
{
    public bool isMenuEnabled;
    [SerializeField] private GameObject canvas;
    LessonScreenManager lesson_screen;

    void Start()
    {
        isMenuEnabled = false;
        lesson_screen = FindAnyObjectByType<LessonScreenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !lesson_screen.is_active)
        {
            isMenuEnabled = !isMenuEnabled;
            canvas.SetActive(isMenuEnabled);
        }
    }
}
