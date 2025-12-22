using UnityEngine;
using TMPro;
using System.Collections.Generic;


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
    public Sprite image;
    
    public LessonScreen(string x, string y, Sprite z)
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
                new LessonScreen("Twoja pierwsza lekcja - Wstęp", "Witaj w swojej pierwszej lekcji w aplikacji KeyLearn! W tej lekcji poznasz rzeczy organizacyjne i nauczysz się podstaw gry na pianinie. Przewiń stronę, aby poznać więcej informacji.", null){},
                new LessonScreen("Twoja pierwsza lekcja - Ergonomia", "Przed rozpoczęciem gry zadbaj o wygodne ułożenie ciała oraz ergonomię rąk. Jeżeli poczujesz, że bolą cię dłonie, przerwij grę, wciskając klawisz ESC i zrób sobie przerwę. Jeżeli po dalszej grze ból nie ustanie, spróbuj zmienić pozycję. Zadbaj o to, aby łokieć był na wysokości pianina i pochylony o 90 stopni.", null){},
                new LessonScreen("Twoja pierwsza lekcja - Dźwięki", "W menu pauzy (ESC) w prawym dolnym rogu znajduje się panel głośności ogólnej, dźwięków metronomu oraz klawiszy. Jeśli uznasz, że metronom nie jest ci potrzebny, możesz go wyciszyć. Wciśnij przycisk \"rozpocznij\", aby przejść do gry na pianinie. Jeśli skońćzysz, włącz menu pauzy i wyjdź.", null){},
            }
        },
        new Lesson
        {
            LessonID = 1,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Ułożenie palców na klawiszach - Wstęp", "Klawisze pianina dzielą się na pewne grupy. Składają się one z 12 klawiszy (7 białych i 5 czarnych) Począwszy od lewej strony, pierwszym klawiszem jest klawisz z literą C definiujący nowy początek grupy. Grup w klawiaturze 61-klawiszowej jest 5: dwie basowe i trzy wiolinowe. Klawisze z grupy basowej należy obsługiwać lewą dłonią, a z grupy wiolinowej prawą.", null),
                new LessonScreen("Ułożenie palców na klawiszach - Palce", "Teraz połóż ostatni palec lewej ręki na klawiszu C, a resztę palców na białych klawiszach znajdujących się obok w kierunku prawym. To samo z prawą dłonią, z tym, że połóż kciuk na klawiszu C.\n\nTwoim ćwiczeniem będzie wciśnięcie kafelków w dwóch gamach w następującej kolejności: C, D, E, F, G, F, E, D, C. Ta sekwencja będzie powtórzona dwukrotnie w danej gamie.", null)
            } 
        },
        new Lesson
        {
            LessonID = 2,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Ułożenie palców na klawiszach", "To ćwiczenie przebiegnie w ten sam sposób jak poprzednie z tym, że spadać będą ciemnoniebieski kafelki. Oznacza to, że będziesz musiał wciskać czarne klawisze.\n\nBędzie to następująca kolejność: C#, D#, F#, G#, A#, G#, F#, D#, C# i tak dwa razy w obu gamach.", null),
            } 
        },
        new Lesson
        {
            LessonID = 3,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Marysia ma małego baranka","Teraz nauczysz się grać bardzo prostą piosenkę: \"Marysia ma małego baranka\". Jest to znana muzyka grana na flażolecie, ale ma ona na celu pomóc Ci wyczuć rytm i melodię. Powodzenia!",null),
            }
        },
        new Lesson
        {
            LessonID = 4,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Siała baba mak - powoli", "Teraz nauczysz się grać prostą melodię piosenki \"Siała baba mak\". W tej lekcji zagrasz tą piosenkę dwa razy w spokojnym tempie. Będą tu występować kafelki, przy których trzeba będzie wcisnąć dwa razy ten sam klawisz, więc przygotuj się. Zagrasz piosenkę w dwóch gamach: wyższej i niższej.", null),
            }
            // do przypisów dodaj książkę nut na flażolecie
        },
        new Lesson
        {
            LessonID = 5,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Siała baba mak - szybciej", "W tej lekcji nauczysz się grać melodię piosenki \"Siała baba mak\", jednak tempo będzie zwiększone. Powodzenia", null),
            }
        },
        new Lesson
        {
            LessonID = 6,
            screen_list = new List<LessonScreen>
            {
                new LessonScreen("Undertale - An Ending", "Wersja demonstracyjna gry, będzie zagrana piosenka \"An Ending\" znana z gry Undertale", null),
            }
        }
    };
}
