using UnityEngine;

public class FallingTileScript : MonoBehaviour
{
    public int key_id;
    public float beat_tempo;
    public float falling_speed = 500;
    public float offset;
    private float new_transform_y;



    private float destroy_height = 230f;

    void Start()
    {
        // zrob to na podstawie: stala wysokosc, zmienny czas zamiast vice versa
        // zamiast vice versa bo zapobiegnie to overflowowi i ulatwi zadanie
        // w skrocie: zostaw to ale w timecontroller.cs ogarnij spawnowanie tego
        // oczywiscie na podstawie zmiennej tempa
        new_transform_y = 4 * offset * falling_speed/beat_tempo;
        transform.position += new Vector3(0f, new_transform_y, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, falling_speed * Time.deltaTime, 0f);
        if (transform.position.y < destroy_height)
        {
            Destroy(gameObject);
        }
    }
}
