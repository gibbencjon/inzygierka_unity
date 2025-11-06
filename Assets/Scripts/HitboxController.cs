using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public bool press_availability;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            Debug.Log("weszlo");
        }
    }
    
    private void onTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            Debug.Log("wyszlooo");
        }
    }
}
