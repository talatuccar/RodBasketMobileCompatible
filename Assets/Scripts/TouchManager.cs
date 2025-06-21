
using UnityEngine;
using UnityEngine.InputSystem;


public class TouchManager : MonoBehaviour
{
    //[SerializeField] private InputActionAsset inputActions;
    private PlayerInput playerInput;
    public static TouchManager Instance { get; private set; }


    private InputAction turnLeftAction;
    private InputAction turnRightAction;
    private InputAction touchPositionAction;
    //private InputAction touchPressAction;

    public static bool isLeftPressed;
    public static bool isRightPressed;
    Vector3 worldPos;
    

    bool isMobile;
    void Awake()
    {
      

        isMobile = Application.isMobilePlatform;

        playerInput = GetComponent<PlayerInput>();

        turnLeftAction = playerInput.actions["GameControl/TurnLeft"];
        turnRightAction = playerInput.actions["GameControl/TurnRight"];
        //touchPressAction = playerInput.actions["GameControl/TouchPress"];
        touchPositionAction = playerInput.actions["GameControl/TouchPosition"];

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
   

    void Update()
    {
        TouchControl();

    }

    private void TouchControl()
    {
        if (!isMobile)
        {
            return;
        }


        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 screenPos = touchPositionAction.ReadValue<Vector2>();
            float cameraZposition = Camera.main.transform.position.z;
            worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, cameraZposition));

            if (worldPos.x > 0)
            {

                print(ScreenManager.Left + "screnamanagerLeft");
                print(worldPos.x + "worldposX");

                isLeftPressed = true;
                isRightPressed = false;

            }
            else
            {
                print(ScreenManager.Right + "screnamanagerRight");
                print(worldPos.x + "worldposX");
               

                isRightPressed = true;
                isLeftPressed = false;

            }
        }
        else
        {
            isLeftPressed = false;
            isRightPressed = false;
            return;
        }
    }

  
    public void RightSettings(InputAction.CallbackContext ctx)
    {
        if (isRightPressed)
        {
            isRightPressed = false;
            return;

        }
        isRightPressed = true;


    }
    public void LeftSettings(InputAction.CallbackContext ctx)
    {

        if (isLeftPressed)
        {
            isLeftPressed = false;
            return;

        }

        isLeftPressed = true;
    }

    private void OnEnable()
    {

        turnLeftAction.Enable();
        turnLeftAction.performed += LeftSettings;
        turnLeftAction.canceled += LeftSettings;


        turnRightAction.Enable();
        turnRightAction.performed += RightSettings;
        turnRightAction.canceled += RightSettings;


        touchPositionAction.Enable();
       

    }

    private void OnDisable()
    {

        turnRightAction.performed -= RightSettings;
        turnRightAction.canceled -= RightSettings;

        turnLeftAction.performed -= LeftSettings;
        turnLeftAction.canceled -= LeftSettings;


        turnLeftAction.Disable();
        turnRightAction.Disable();

      

        touchPositionAction.Disable();

    }

}
