// skrypt podpiety pod scene z keyboardem

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LessonScreenManager : MonoBehaviour
{
    [SerializeField] private TMP_Text title_text;
    [SerializeField] private TMP_Text desc_text;
    [SerializeField] private TMP_Text page_counter;
    [SerializeField] private Button start_button;
    [SerializeField] private GameObject lesson_screen;
    TimelineController timeline_ctrl;
    [SerializeField] CurrentLevelScriptableData current_level_data;
    
    
    // dopisz ze do przyciskow przypisano funkcje GoToNextPage i GoToPrevPage

    private Lessons lessons;
    private Lesson current_lesson;

    private int page = 0;
    public bool is_active = true;


    void Start()
    {
        GetLessonData();
        timeline_ctrl = FindAnyObjectByType<TimelineController>();
        lesson_screen.SetActive(true);
    }


    void GetLessonData()
    {
        lessons = GetComponent<Lessons>();
        current_lesson = lessons.lesson_list[current_level_data.GetLevelID()];

        try
        {
            if (current_lesson.screen_list.Count == 0)
            {
                title_text.text = "Gotowy?";
                desc_text.text = "Wcisnij przycisk \"Rozpocznij\", aby zacząć grę";
                return;
            }
            for (int i = 0; i <= current_lesson.screen_list.Count; i++)
            {
                if (i == page)
                {
                    title_text.text = current_lesson.screen_list[i].title_text;
                    desc_text.text = current_lesson.screen_list[i].desc_text;
                }
            }
        }
        catch (ArgumentOutOfRangeException) {}
        page_counter.text = "" + (page + 1) + "/" + current_lesson.screen_list.Count;
    }


    // funkcje przyciskow
    public void GoToNextPage()
    {
        if (page < current_lesson.screen_list.Count - 1) {page++;}
        GetLessonData();
    }

    public void GoToPrevPage()
    {
        if (page > 0) {page--;}
        GetLessonData();
    }

    public void BeginGameplay()
    {
        lesson_screen.SetActive(false);
        timeline_ctrl.is_timeline_initiated = true;
        is_active = false;
    }
}
