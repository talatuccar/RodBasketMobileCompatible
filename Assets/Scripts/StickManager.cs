using UnityEngine;
public class StickManager : MonoBehaviour
{
    //InputActions inputActions;
   
    float xPosition { get; set; }
    //bool isLeftPressed;
    //bool isRightPressed;
    public int shootPower;

    bool isTurning;
    int rotationSpeed = 80;
    //bool isMobile;
    bool isGameTouch;
    Vector3 inputDirection;
    //int sayac;
    private void Awake()
    {
        //isMobile = Application.isMobilePlatform;
        //print(isMobile + "isMobile");
        //inputActions = new InputActions();
 
       

        //input class yöntemi 
        //inputActions.GameControl.TurnRight.performed += ctx => isRightPressed = ctx.ReadValueAsButton();
        //inputActions.GameControl.TurnRight.canceled += ctx => isRightPressed = ctx.ReadValueAsButton();


        //inputActions.GameControl.TurnLeft.performed += ctx => isLeftPressed = ctx.ReadValueAsButton();
        //inputActions.GameControl.TurnLeft.canceled += ctx => isLeftPressed = ctx.ReadValueAsButton();



        // Using Methods
        //inputActions.GameControl.TurnRight.performed += _ => RightSettings();
        //inputActions.GameControl.TurnRight.canceled += _ => RightSettings();

        //inputActions.GameControl.TurnLeft.performed += x => LeftSettings();
        //inputActions.GameControl.TurnLeft.canceled += x => LeftSettings();


    }

    //Using Methods
    //public void RightSettings(InputAction.CallbackContext ctx)
    //{
    //    if (isRightPressed)
    //    {
    //        isRightPressed = false;
    //        return;

    //    }
    //        isRightPressed = true;
      
        
    //}
    //public void LeftSettings(InputAction.CallbackContext ctx)
    //{

    //    if (isLeftPressed)
    //    {
    //        isLeftPressed = false;
    //        return;

    //    }


    //    //if (!isMobile)
    //        isLeftPressed = true;

    //    //transform.rotation *= Quaternion.Euler(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    //}



    //void TouchSettings(InputAction.CallbackContext ctx)
    //{
      


    //    if (sayac>1)
    //    {
    //        Vector2 directionIký = ctx.ReadValue<Vector2>();
    //        print(directionIký + "directiýonýký");
    //        Vector3 directionUc = new Vector3(directionIký.x, directionIký.y, 0);
    //        directionUc.z = -Camera.main.transform.position.z;
    //        Vector3 position = Camera.main.ScreenToWorldPoint(directionUc);

    //        if (ScreenManager.Left / 2 > position.x)
    //        {


    //            print(position.x + "position.x");
    //            print(position.y + "position.y");
    //            print(position.z + "position.z");
               
    //            isLeftPressed = true;
    //        }
    //        else
    //        {
                
    //            isRightPressed = true;

    //        }


    //    }
    //    else
    //    {
    //        sayac++;
    //        print(sayac);
    //        //isGameTouch = true;
    //    }



    //}

    //void TouchCanceled(InputAction.CallbackContext ctx)
    //{
    //    isLeftPressed=false;
    //    isRightPressed=false;
    //}

    void Update()
    {

        if (TouchManager.isLeftPressed)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, rotationSpeed * Time.deltaTime));


        }


        if (TouchManager.isRightPressed)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));

            // alternative way to rotate it
            //transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));

        }



    }

    private void OnCollisionEnter(Collision collision)
    {

        Vector3 poz = collision.GetContact(0).point;
        if (gameObject.transform.position.y > poz.y)
        {

            collision.gameObject.GetComponent<Rigidbody>().AddForce(poz * shootPower);

        }

        return;

    }

    //private void OnEnable()
    //{
    //    turnLeftAction = inputActions.FindAction("GameControl/TurnLeft");
    //    turnLeftAction.Enable();
    //    turnLeftAction.performed += LeftSettings;
    //    turnLeftAction.canceled += LeftSettings;

    //    turnRightAction = inputActions.FindAction("GameControl/TurnRight");
    //    turnRightAction.Enable();
    //    turnRightAction.performed += RightSettings;
    //    turnRightAction.canceled += RightSettings;

    //    touchAction = inputActions.FindAction("GameControl/Touch");
    //    touchAction.Enable();
    //    touchAction.performed += TouchSettings;
    //    touchAction.canceled += TouchCanceled;


    //}

    //private void OnDisable()
    //{
    //    turnLeftAction.Disable();
    //    turnLeftAction.performed -= LeftSettings;
    //    turnRightAction.Disable();
    //    turnRightAction.performed -= RightSettings;
    //    turnRightAction.canceled -= RightSettings;
    //    turnLeftAction.canceled -= LeftSettings;

    //    touchAction.Disable();
    //    touchAction.performed -= TouchSettings;
    //    touchAction.canceled -= TouchCanceled;
    //}

}
