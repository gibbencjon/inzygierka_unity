using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    public AudioSource tick_up;
    public AudioSource tick_down;
    public GameObject beat_line;
    public Transform parent;
    public int tact = 4;
    public float beat_tempo; // w razie potrzeby zserializowac
    private float current_time = 0f;
    private float beat_delta;
    private float beat_test;

    // falling tiles
    public GameObject key_white; // potrzebne do instancji
    public GameObject key_black;
    private List<GameObject> white_keys_list = new List<GameObject>();
    private List<GameObject> black_keys_list = new List<GameObject>();

    // Timeline
    public float falling_speed;
    public float offset = 247f; 
    private float beat_delta_timeline;
    private bool is_timeline_initiated;

    // metronom
    private int tick = 0;
    private float beat_delta_metronome;
    private bool is_metronome_active;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beat_delta = 60f / beat_tempo; // zakladajac ze w ciagu 60 sekund wystepuje iles beatow
        // usunieto to z void update bo teraz zmiany bpm i beat delta beda na biezaco z edytora
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
        moveBeatline.offset = offset;

        // 267 - 200 BPM
        // 264 - 180 bpm
        // 263 - 174 bpm
        // 257 - 160 bpm
        // 254 - 140 bpm
        // 254 - 120 bpm
        // 246 - 60 bpm

    }

    private void SpawnBeatLine()
    {
        CreateBeatlineObject();
        Debug.Log("obiekt utworzono");
    }

    private void SpawnFallingTile(string tile_type, int key_select) // klawisze sa zliczane od 1 a nie od 0 dla wygody
    {
        if (tile_type == "w")
        {
            GameObject new_falling_tile = Instantiate(key_white, transform.position, Quaternion.identity, parent);
            FallingTileScript move_falling_tile = new_falling_tile.AddComponent<FallingTileScript>();
            move_falling_tile.beat_tempo = beat_tempo;
            
            
            // move_falling_tile.transform.position = new_falling_tile.GetComponent<Transform>().position

            // utwórz zmienną która wyliczy odległość w zależności od tempa, przypisz domyślną pozycję na dole i dodaj obiekt wyżej
            
        }
        else if (tile_type == "b")
        {
            GameObject new_falling_tile = Instantiate(key_black, transform.position, Quaternion.identity, parent);
            FallingTileScript move_falling_tile = new_falling_tile.AddComponent<FallingTileScript>();
            move_falling_tile.beat_tempo = beat_tempo;

        }
        else { Debug.Log("Nienznay typ obiektu white/black"); }
            
    }

    private void SummonMetronomeSound()
    {
        if (tick == 0) { tick_up.Play(); }
        else { tick_down.Play(); }
        tick += 1;
        if (tick >= tact) { tick = 0; }  
    }
    


    // Update is called once per frame
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnFallingTile("w", 1);
        }

        // jesli wcisniesz spacje to zaczyna leciec timer
        if (is_timeline_initiated)
        {
            current_time += Time.deltaTime;
            beat_delta_metronome -= Time.deltaTime;
            beat_delta_timeline += Time.deltaTime;
            
            


            // dodac warunek ukonczenia np. gdy wszystkie kafelki zostana pokazane
            // albo gdy po ostatnim kafelku uplynie iles czasu
            // spawnij obiekty tak zeby timing byl przy klawiszu

            // najlepiej by bylo zrobic cala mechanike beatow i tactow w tym miejscu w void update
            // na podstawie pewnej delty mozna wyliczyc kiedy obiekt ma sie spawnic
            if (beat_delta_timeline >= CountBeatDelta(60 * tact))
            {
                SpawnBeatLine();
                beat_delta_timeline -= CountBeatDelta(60 * tact);
            }


            if (beat_delta_metronome <= 0f)
            {
                SummonMetronomeSound();
                beat_delta_metronome += 60f / beat_tempo;

            }

        }
        
    }
}

