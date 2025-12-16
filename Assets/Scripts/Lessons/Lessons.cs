using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;

public class Lesson
{
    public int LessonID;
    public List<LessonScreen> screen_list;
}


public class LessonScreen : Lesson
{
    // nie ma potrzeby tworzenia ID bo łatwiej skorzystać z elementu listy;
    public string title_text;
    public string desc_text;
    public Image image;
    
    public LessonScreen(string x, string y, Image z)
    {
        title_text = x;
        desc_text= y;
        image = z;
    }
}


public class Lessons : MonoBehaviour
{
    public List<Lesson> lesson_list = new List<Lesson>()
    {
        new Lesson
        {
            LessonID = 0,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Tytuł", "Podtytuł, czyli rozwiązanie zagadki dokąd nocą tupta jeż", null){},
                new LessonScreen("To chyba screen 2", "Nie jestem pewien, ale nie oceniam", null){},
                new LessonScreen("Część dalsza bolączek", "Zapewniam, że nie jestem pewien co robię", null){},
                new LessonScreen("To chyba 3 strona", "Ale jesteśmy na czwartej. Może lepiej pójdę spać ", null){},
                new LessonScreen("To jak?", "Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet Lorem Ipsum DOlor Sil Amet  ", null){},
            }
        },
        new Lesson
        {
            LessonID = 1,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Test kafelków", "znowu sie widzimy, co?", null),
            } 
        },
        new Lesson
        {
            LessonID = 2,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Test kafelka", "Zaraz spadnie jeden kafelek, scena została stworzona w celu debugowania i testowania", null),
            } 
        }
    };
}
