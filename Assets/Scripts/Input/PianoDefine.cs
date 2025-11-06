using UnityEngine;
using UnityEngine.InputSystem;

public class PianoDefine : MonoBehaviour
{
    public static PianoDefine instance;
    
    public bool isButton1Pressed { get; private set; }
    public bool isButton2Pressed { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _pressWhite1;
    private InputAction _pressWhite2;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            _playerInput = GetComponent<PlayerInput>();
            SetupInputs();
            Debug.Log("wlaczono instancje");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("zniszczono instancje");
        }

        
    }


    void Update()
    {
        UpdateInputs();
    }

    void SetupInputs()
    {
        _pressWhite1 = _playerInput.actions["white1"];
        _pressWhite2 = _playerInput.actions["white2"];
    }

    private void UpdateInputs()
    {
        isButton1Pressed = _pressWhite1.IsPressed();
        isButton2Pressed = _pressWhite2.IsPressed();
    }
}
