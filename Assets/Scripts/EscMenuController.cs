using UnityEngine;
using UnityEngine.UI;

public class EscMenuController : MonoBehaviour
{
    private bool isMenuEnabled;
    [SerializeField]
    private GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMenuEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuEnabled = !isMenuEnabled;
            canvas.SetActive(isMenuEnabled);
        }
    }
}
