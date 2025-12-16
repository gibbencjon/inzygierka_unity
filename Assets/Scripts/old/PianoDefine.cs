// using UnityEngine;
// using MidiJack;
// using System.Collections.Generic;
// using UnityEngine.InputSystem;
// using Unity.VisualScripting;

// ten skrypt jest do wywalenia w związku z tym że key_instance_script
// bierze na klatę całą mechanikę sterowania

// public class PianoDefine : MonoBehaviour
// {
//     // pierw trzeba wybrac gameobjecty z ktorych beda pobierane dzieci i dodawane do listy
//     [SerializeField] private GameObject whites_parent;
//     [SerializeField] private GameObject blacks_parent;
//     [SerializeField] private GameObject audio_source_parent;


//     private Color dark_white = new Color(0.75f, 0.75f, 0.75f, 1f);    

//     private List<GameObject> whites_list = new List<GameObject>();
//     private List<GameObject> blacks_list = new List<GameObject>();
//     public List<GameObject> sorted_key_list = new List<GameObject>();
//     private List<AudioSource> audio_source_list = new List<AudioSource>();

//     // jesli zajdzie potrzeba uzycia PlayOneShot() to trzeba odkomentowac
//     // private List<AudioClip> audio_clips_list = new List<AudioClip>();

//     // kazdy obiekt z listy zawiera dziecko ktorym jest SpriteRenderer, chce mu zmienic kolor
//     private List<SpriteRenderer> key_square = new List<SpriteRenderer>();
//     private List<Color> key_color = new List<Color>();
//     private bool[] isPlaying = new bool[62];

    

//     void Awake()
//     {
        
//         // przepisz kod w taki sposob zeby korzystal z kolorow z instance script
//         // key_instance_script key_instance = GetComponentInChildren<key_instance_script>();
        
//         // pierw trzeba dac do listy elementy typu gameobject
//         foreach (Transform child in whites_parent.transform)
//         {
//             whites_list.Add(child.gameObject);
//         }

//         foreach (Transform child in blacks_parent.transform)
//         {
//             blacks_list.Add(child.gameObject);
//         }


//         // tu jest kod w ktorym sortuje liste bialych i czarnych polaczona razem w taki sposob jak jest w rzeczywistosci
//         // czyli bialy, czarny, bialy itd. (schemat klawiszy 5 / 7)
//         int white_key_index = 0;
//         int black_key_index = 0;
//         bool ktory_klawisz_teraz = false;
//         for (int i = 0; i < 10; i++)
//         {
//             if (ktory_klawisz_teraz == false)
//             {
//                 for (int j = 0; j < 5; j++)
//                 {
//                     if (j % 2 == 0)
//                     {
//                         sorted_key_list.Add(whites_list[white_key_index]);
//                         key_color.Add(dark_white);
//                         white_key_index++;
//                     }
//                     else
//                     {
//                         sorted_key_list.Add(blacks_list[black_key_index]);
//                         key_color.Add(Color.black);
//                         black_key_index++;
//                     }
//                 }
//                 ktory_klawisz_teraz = true;
//             }
//             else
//             {
//                 for (int k = 0; k < 7; k++)
//                 {
//                     if (k % 2 == 0)
//                     {
//                         sorted_key_list.Add(whites_list[white_key_index]);
//                         key_color.Add(Color.white);
//                         white_key_index++;
//                     }
//                     else
//                     {
//                         sorted_key_list.Add(blacks_list[black_key_index]);
//                         key_color.Add(Color.black);
//                         black_key_index++;
//                     }
//                 }
//                 ktory_klawisz_teraz = false;
//             }
//         }
//         sorted_key_list.Add(whites_list[white_key_index]);

//         // jesli lista polaczonych klawiszy jest zrobiona, mozna usunac liste bialych i czarnych
//         whites_list = null;
//         blacks_list = null;

//         foreach (GameObject obj in sorted_key_list)
//         {
//             SpriteRenderer square = obj.GetComponentInChildren<SpriteRenderer>();
//             key_square.Add(square);

//         }
//         // Debug.Log("klawisze w liscie: " + sorted_key_list.Count);

//         // teraz dodac dzwieki klawiszy
//         foreach (Transform child in audio_source_parent.transform)
//         {
//             AudioSource src = child.GetComponent<AudioSource>();
//             audio_source_list.Add(src);

//             // odkomentowac jesli trzeba uzyc PlayOneShot() zamiast Play()
//             // audio_clips_list.Add(src.clip); 
//         }
//     }

//     void NoteOn(MidiChannel channel, int note, float velocity)
//     {
//         // Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
//         key_square[note - 36].color = Color.green;
//         Debug.Log(note - 36 + "pressed");
        
       
//         if (!isPlaying[note - 36]) // czy dźwięk już gra czy nie?
//         {
//             // audio_source_list[note - 36].PlayOneShot(audio_clips_list[note - 36]);
//             audio_source_list[note - 36].Play();
//             isPlaying[note - 36] = true; // Ustaw flagę, że dźwięk jest odtwarzany
//         }
//     }

//     void NoteOff(MidiChannel channel, int note)
//     {
//         // Debug.Log("NoteOff: " + channel + "," + note);
//         key_square[note - 36].color = key_color[note - 36];
//         isPlaying[note - 36] = false;
        
//     }

    

//     void OnEnable()
//     {
//         MidiMaster.noteOnDelegate += NoteOn;
//         MidiMaster.noteOffDelegate += NoteOff;
//         // MidiMaster.knobDelegate += Knob;
//     }

//     void OnDisable()
//     {
//         MidiMaster.noteOnDelegate -= NoteOn;
//         MidiMaster.noteOffDelegate -= NoteOff;
//         // MidiMaster.knobDelegate -= Knob;
//     }
// }
