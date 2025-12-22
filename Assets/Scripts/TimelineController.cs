using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TimelineController : MonoBehaviour
{
    public AudioSource source_tick_up;
    public AudioSource source_tick_down;
    private AudioClip clip_tick_up;
    private AudioClip clip_tick_down;

    

    public EscMenuController esc_menu_ctrl;

    // falling tiles
    public GameObject key_white; // potrzebne do instancji
    public GameObject key_black;

    // beatline
    public GameObject beat_line;
    public Transform parent;
    public float falling_speed;
    public float offset = 247f; 
    private float beat_delta_timeline;

    // Timeline
    private int tact;
    public float beat_tempo;
    public float current_time = 0f;
    private float ending_time;
    private bool activate_ending_mechanism;

    private float beat_delta_metronome;
    public bool is_timeline_initiated;
    

    // metronom
    private int tick = 0;

    // tu jest import beatmapy ze skryptu
    List<object> level;
    [SerializeField] private CurrentLevelScriptableData current_level;


    // spawnowanie kafelkow
    public FallingTileScript[] spawned_objects;
    FallingTileController falling_controller;
    public int tiles_pressed;

    ScoreManager score_manager;
    


    void Start()
    {
        falling_controller = FindAnyObjectByType<FallingTileController>();
        esc_menu_ctrl = FindAnyObjectByType<EscMenuController>();
        score_manager = FindAnyObjectByType<ScoreManager>();
        clip_tick_up = source_tick_up.clip;
        clip_tick_down = source_tick_down.clip;

        score_manager.DeactivateScoreScreen();

        level = current_level.GetNextLevelToLoad();
        beat_tempo = current_level.GetLevelBPM();
        tact = current_level.GetLevelTact();
        offset = current_level.GetLeveLDelay();
        // Debug.Log(level.Count);

        
        
    }

    private float CountBeatDelta(float x)
    {
        return x / beat_tempo;
    }


    private void CreateBeatlineObject()
    {
        GameObject new_beat_line = Instantiate(beat_line, transform.position, Quaternion.identity, parent);
        beatline_movement moveBeatline = new_beat_line.AddComponent<beatline_movement>();
        moveBeatline.beat_tempo = beat_tempo;
        moveBeatline.falling_speed = falling_speed;

        // 267 - 200 BPM
        // 264 - 180 bpm
        // 263 - 174 bpm
        // 257 - 160 bpm
        // 254 - 140 bpm
        // 254 - 120 bpm
        // 246 - 60 bpm

    }


    private void SummonMetronomeSound()
    {
        // mozesz sprobowac zsynchronizowac pozycje timeline'a z pozycja
        if (tick == 0) { source_tick_up.PlayOneShot(clip_tick_up); }
        else { source_tick_down.PlayOneShot(clip_tick_down); }
        tick += 1;
        if (tick >= tact) { tick = 0; }
    }
    
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!is_timeline_initiated)
            {
                is_timeline_initiated = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            is_timeline_initiated = false;
            current_time = 0f;
        }

        
        // jesli wcisniesz spacje to zaczyna leciec timer
        if (is_timeline_initiated)
        {
            // to musi tu byc
            // mimo tego ze inne skrypty z niego korzystaja to tu jest warunek spawnowania
            spawned_objects = FindObjectsByType<FallingTileScript>(FindObjectsSortMode.None);
            
            if (!esc_menu_ctrl.isMenuEnabled)
            {
                current_time += Time.deltaTime;
                beat_delta_timeline -= Time.deltaTime;
                beat_delta_metronome -= Time.deltaTime;
            }

            if (beat_delta_timeline <= 0f)
            {
                CreateBeatlineObject();
                beat_delta_timeline += CountBeatDelta(120f * tact);
            }

            if (beat_delta_metronome + offset/1000f <= 0f)
            {
                SummonMetronomeSound();
                beat_delta_metronome += CountBeatDelta(60f);
            }


            


            if (activate_ending_mechanism)
            {
                if (ending_time <= 2f)
                {
                    ending_time += Time.deltaTime;
                }
                else
                {
                    is_timeline_initiated = false;
                    score_manager.ActivateScoreScreen();
                }
                
            }

            try
            {

                for (int i = 0; i < level.Count; i+=3)
                {
                    // if (spawned_objects.Length > 100) return;
                    if (i + 2 < level.Count)
                    {
                        // https://stackoverflow.com/questions/69427121/in-c-sharp-how-i-can-convert-from-object-to-float
                        // parsujesz drugi element z listy beatmapy czyli wyciagasz z niego floata
                        float delay = float.Parse(level[i+1].ToString());
                        if (current_time >= CountBeatDelta(delay * 60) && (int)level[i+2] == 0)
                        {
                            falling_controller.CreateFallingTile((int)level[i], delay);
                            level[i+2] = 1;
                        }
                        // warunek konca beatmapy
                        if (tiles_pressed == level.Count/3)
                        {
                            activate_ending_mechanism = true;
                        }
                    }
                }
            }
            catch (NullReferenceException) {Debug.Log("nie zaladowano elementow beatmapy"); is_timeline_initiated = false; return;}
        }
    }
}

