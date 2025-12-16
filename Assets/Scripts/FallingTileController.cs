using System.Collections.Generic;
using UnityEngine;

public class FallingTileController : MonoBehaviour
{

    // key_instance_script[] key_instance;
    TimelineController timeline_ctrl;
    public GameObject key_white;
    public GameObject key_black;
    private List<float> keys_pos = new List<float>
    {
        -933.33f, -910.6174f, -879.9966f, -849.3829f, -826.6633f, -773.33f, -750.6174f, -719.9966f, -693.3334f, -666.6633f, -636.0495f, -613.33f, -559.9966f, -537.2841f, -506.6633f, -476.0495f, -453.3299f, -399.9966f, -377.284f, -346.6632f, -320.0001f, -293.3299f, -262.7161f, -239.9965f, -186.6632f, -163.9507f, -133.3298f, -102.7161f, -79.99651f, -26.66317f, -3.950618f, 26.67017f, 53.33334f, 80.00352f, 110.6173f, 133.3369f, 186.6702f, 209.3828f, 240.0035f, 270.6173f, 293.3369f, 346.6702f, 369.3828f, 400.0036f, 426.6667f, 453.3369f, 483.9507f, 506.6703f, 560.0036f, 582.7161f, 613.337f, 643.9507f, 666.6703f, 720.0037f, 742.7162f, 773.337f, 800.0001f, 826.6703f, 857.2841f, 880.0037f, 933.337f
    };

    
    void Start()
    {
        timeline_ctrl = FindAnyObjectByType<TimelineController>();

    }


    public void CreateFallingTile(int id, float spawn_time)
    {
        GameObject placeholder;
        // FallingObject falling_tile = new FallingObject();
        if (id == 0 || id == 2 || id == 4 || id == 5 || id == 7 || id == 9 || id == 11 || id == 12 || id == 14 || id == 16 ||
        id == 17 || id == 19 || id == 21 || id == 23 || id == 24 || id == 26 || id == 28 || id == 29 || id == 31 || id == 33 ||
        id == 35 || id == 36 || id == 38 || id == 40 || id == 41 || id == 43 || id == 45 || id == 47 || id == 48 || id == 50 ||
        id == 52 || id == 53 || id == 55 || id == 57 || id == 59 || id == 60)
        {
            placeholder = key_white;
        }
        else if (id == 1 || id == 3 || id == 6 || id == 8 || id == 10 || id == 13 || id == 15 || id == 18 || id == 20 || id == 22 ||
        id == 25 || id == 27 || id == 30 || id == 32 || id == 34 || id == 37 || id == 39 || id == 42 || id == 44 || id == 46 || 
        id == 49 || id == 51 || id == 54 || id == 56 || id == 58)
        {
            placeholder = key_black;
        }
        else { Debug.Log("Nienznay typ obiektu white/black"); placeholder = key_white; }
        GameObject new_falling_tile = Instantiate(placeholder, transform.position, Quaternion.identity);
        FallingTileScript move_falling_tile = new_falling_tile.AddComponent<FallingTileScript>();
        move_falling_tile.key_id = id;
        move_falling_tile.beat_tempo = timeline_ctrl.beat_tempo;
        move_falling_tile.new_transform_x = keys_pos[id];
        move_falling_tile.spawn_time = spawn_time;
        // timeline_ctrl.objects_to_spawn.Add(move_falling_tile);
        // Debug.Log("dlugosc listy: " + timeline_ctrl.objects_to_spawn.Count + ", najnowszy element: " + move_falling_tile);
        // Debug.Log("key id: " + id + ", spawnpoint: " + keys_pos[id]);
    }


}
