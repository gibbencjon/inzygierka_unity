using UnityEngine;

public class beatline_movement : MonoBehaviour
{

    // beatline movement zostal tez przypisany do klawiszy

    public float beat_tempo;
    public float falling_speed = 800f;
    public float offset;
    private float destroy_height = 230f; // mierzone od dolu kanwy a nie od srodka
    private float new_transform_y;

    
    void Start()
    {
        // spawnpoint przy linii to -292.54f (mierzony od srodka kanwy)
        // spawnpoint na gorze to 542.5
        // laczna wysokosc to 835.4
        // transform.position += new Vector3(0f, 542.5f, 2f); //2f zostal dodany zeby ukryc pasek za keyboardem

        // moja droga jest nieznana
        // czas to beaty na sekunde (120)
        // predkosc to falling_speed

        new_transform_y = -292.54f + offset * falling_speed/beat_tempo;
        transform.position += new Vector3(0f, new_transform_y, 2f);
        // Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, falling_speed * Time.deltaTime, 0f); 
        if (transform.position.y <= destroy_height)
        {
            Destroy(gameObject);
        }
    }
}
