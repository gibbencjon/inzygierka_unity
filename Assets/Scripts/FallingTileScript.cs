using UnityEngine;
using UnityEngine.UIElements;


public class FallingTileScript : MonoBehaviour
{
    public int key_id;
    public float beat_tempo; // moge skorzystac z timeline_ctrl zeby uzyc tempo
    public float falling_speed = 300f;
    public float offset;
    public float new_transform_x;
    public float new_transform_y;
    public bool collides_with_hitbox_early;
    public bool collides_with_hitbox_perfect;
    public bool collides_with_hitbox_late;
    public bool deleted;
    // FallingObject falling_tile = new FallingObject();
    private float destroy_height = 190f; //230f;
    public bool isSpawned = false;
    public float spawn_time;
    TimelineController timeline_ctrl;


    void Start()
    {
        timeline_ctrl = FindAnyObjectByType<TimelineController>();
        
        new_transform_y = 540f + offset * falling_speed/beat_tempo;
        transform.position += new Vector3(new_transform_x, new_transform_y, 2f);

        // poprzednie poprawki ze skalowaniem, wiecej tego nie ruszam
        float scale_x = transform.localScale.x;
        float scale_y = transform.localScale.y;
        transform.localScale = new Vector3(scale_x * 1.975309f, scale_y, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeline_ctrl.esc_menu_ctrl.isMenuEnabled)
        {
            transform.position -= new Vector3(0f, falling_speed * Time.deltaTime, 0f);
        }
        if (transform.position.y <= destroy_height)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyTile()
    {
        timeline_ctrl.tiles_pressed ++;
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("hitbox_early"))
        {
            collides_with_hitbox_early = true;
            // Debug.Log(key_id + " early enter");
        }
        if (other.gameObject.CompareTag("hitbox_perfect"))
        {
            collides_with_hitbox_perfect = true;
            // Debug.Log(key_id + " perfect enter");
        }
        if (other.gameObject.CompareTag("hitbox_late"))
        {
            collides_with_hitbox_late = true;
            // Debug.Log(key_id + " late enter");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hitbox_early"))
        {
            collides_with_hitbox_early = false;
            // Debug.Log(key_id + " early exit");
            //Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("hitbox_perfect"))
        {
            collides_with_hitbox_perfect = false;
            // Debug.Log(key_id + " perfect exit");
        }
        if (other.gameObject.CompareTag("hitbox_late"))
        {
            collides_with_hitbox_late = false;
            deleted = true;
            DestroyTile();
            
            // Debug.Log(key_id + " late exit");
        }
    }
}
