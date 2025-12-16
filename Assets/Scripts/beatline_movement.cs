using UnityEngine;

public class beatline_movement : MonoBehaviour
{

    // beatline movement zostal tez przypisany do klawiszy

    public float beat_tempo;
    public float falling_speed = 800f;
    private float destroy_height = 230f; // mierzone od dolu kanwy a nie od srodka
    private float new_transform_y;
    TimelineController timeline_ctrl;
    
    void Start()
    {
        timeline_ctrl = FindAnyObjectByType<TimelineController>();
        new_transform_y = 536f;
        // new_transform_y = -292.54f + offset * falling_speed/beat_tempo;
        transform.position += new Vector3(0f, new_transform_y, 5f);
        // Debug.Log(transform.position);
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
    
}
