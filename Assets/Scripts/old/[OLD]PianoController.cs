using UnityEngine;

public class OldPianoController : MonoBehaviour
{
    private SpriteRenderer piano_key;
    private Color color_depressed;
    private Color white_pressed = new Color(0.3f, 1f, 0.3f, 1f);
    private Color black_pressed = new Color(0.3f, 0.6f, 1f, 1f);


    [SerializeField]
    public KeyCode current_pressed_key;
    public bool isBlack;
    void Start()
    {
        piano_key = GetComponent<SpriteRenderer>();
        color_depressed = piano_key.color;

    }


    void Update()
    {
        if (Input.GetKeyDown(current_pressed_key))
        {
            if (isBlack == true)
            {
                piano_key.color = black_pressed;
            }
            else
            {
                piano_key.color = white_pressed;
            }
        }
        if (Input.GetKeyUp(current_pressed_key))
        {
            piano_key.color = color_depressed;
        }
    }



    
}
