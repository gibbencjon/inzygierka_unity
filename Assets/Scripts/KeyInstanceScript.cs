using TMPro;
using UnityEngine;
using System;
using MidiJack;

public class KeyInstanceScript : MonoBehaviour
{
    public int id;
    private SpriteRenderer square;
    private TextMeshProUGUI key_text;
    private bool isSoundPlaying;
    private float red_timer;
    private bool turn_red;
    TimelineController timeline_ctrl;
    private ScoreManager score_manager;
    
    [SerializeField] private bool isBlack;
    [SerializeField] private string key_label;
    // kolor zdefiniowanego klawisza, nie mylic z ponizszymi kolorami
    [SerializeField] private Color tile_color;
    [SerializeField] private AudioSource sound;
    

    // kolory
    private Color key_color_early_late = new Color(1, 0.7f, 0, 1);
    private Color key_color_perfect = new Color(0, 1, 0, 1);
    private Color key_color_missed = new Color(1,0,0,1);


    void Start()
    {
        square = GetComponentInChildren<SpriteRenderer>();
        key_text = GetComponentInChildren<TextMeshProUGUI>();
        timeline_ctrl = FindAnyObjectByType<TimelineController>();
        score_manager = FindAnyObjectByType<ScoreManager>();

        // mechanika klawisza bez zaleznosci kafelka
        if (tile_color != Color.clear)
        {
            square.color = tile_color;
        }
        key_text.text = key_label;

        key_text.fontSize = isBlack ? 12 : 15; // potrenować if else
    }


    void Update()
    {
        try
        {
            foreach (FallingTileScript tile in timeline_ctrl.spawned_objects)
            {
                if (id == tile.key_id)
                {
                    if (tile.deleted == true && turn_red == false)
                    {
                        turn_red = true;
                        score_manager.tiles_missed += 1;
                        // timeline_ctrl.objects_to_spawn.RemoveAt(0);
                        sound.Play();
                    }
                }
            }
        }
        catch (IndexOutOfRangeException) {return;}
        
        // jezeli kafelek zostanie usuniety, klawisz ma zmienic kolor na czerwony, potem na oryginalny
        if (turn_red == true)
            {
                red_timer += Time.deltaTime;
                if (red_timer <= 0.1f)
                {
                    square.color = key_color_missed;
                }
                else
                {
                    square.color = tile_color;
                    red_timer = 0f;
                    turn_red = false;
                }
            }
    }


    void NoteOn(MidiChannel channel, int note, float velocity)
    {
        // Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
        if ((note - 36) == id)
        {
            if (!isSoundPlaying)
            {
                sound.Play();
                square.color = key_color_perfect;
            }
            try
            {
                foreach (FallingTileScript tile in timeline_ctrl.spawned_objects)
                {
                    if ((note - 36) == tile.key_id)
                    {
                        if (tile.collides_with_hitbox_early == true) 
                        {
                            // Debug.Log("early " + tile.key_id);
                            square.color = key_color_early_late;
                            score_manager.final_score += 50;
                            score_manager.tiles_hit_early += 1;
                            tile.DestroyTile();
                        }
                        else if (tile.collides_with_hitbox_perfect == true) 
                        {
                            // Debug.Log("perfect " + tile.key_id);
                            square.color = key_color_perfect;
                            score_manager.final_score += 100;
                            score_manager.tiles_hit_perfect += 1;
                            tile.DestroyTile();
                        }
                        else if (tile.collides_with_hitbox_late == true)
                        {
                            // Debug.Log("late " + tile.key_id);
                            square.color = key_color_early_late;
                            score_manager.final_score += 50;
                            score_manager.tiles_hit_late += 1;
                            tile.DestroyTile();
                        }
                        // else if (tile.deleted == true)
                        // {
                        //     // square.color = key_color_missed;
                        // tutaj to nie zadziala, musi byc w petli void update
                        // }
                    }
 
                }
            }
            catch (IndexOutOfRangeException) {return;}

            isSoundPlaying = true;
        }
    }

    void NoteOff(MidiChannel channel, int note)
    {
        // Debug.Log("NoteOff: " + channel + "," + note);
        if ((note - 36) == id)
        {
            square.color = tile_color;
            isSoundPlaying = false;
        }
    }

    // ponizsze jest niepotrzebne bo nie korzystam z knobow w tym projekcie
    // void Knob(MidiChannel channel, int knobNumber, float knobValue)
    // {
    //     Debug.Log("Knob: " + knobNumber + "," + knobValue);
    // }

    void OnEnable()
    {
        MidiMaster.noteOnDelegate += NoteOn;
        MidiMaster.noteOffDelegate += NoteOff;
        // MidiMaster.knobDelegate += Knob;
    }

    void OnDisable()
    {
        MidiMaster.noteOnDelegate -= NoteOn;
        MidiMaster.noteOffDelegate -= NoteOff;
        // MidiMaster.knobDelegate -= Knob;
    }
}
