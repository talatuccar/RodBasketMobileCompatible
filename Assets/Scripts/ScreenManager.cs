using UnityEngine;

public static class ScreenManager
{
    static float left;
    static float right;
    //static bool isInitialized;

    public static float Left
    {
        get
        {
            //if (!isInitialized) Init();
            return left;
        }
    }

    public static float Right
    {
        get
        {
            //if (!isInitialized) Init();
            return right;
        }
    }

    public static void Init()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera not found!");
            return;
        }

        float zAxis = -Camera.main.transform.position.z;

        Vector3 screenOrigin = new Vector3(0, 0, zAxis);
        Vector3 screenTopRight = new Vector3(Screen.width, Screen.height, zAxis);

        Vector3 worldOrigin = Camera.main.ScreenToWorldPoint(screenOrigin);
        Vector3 worldTopRight = Camera.main.ScreenToWorldPoint(screenTopRight);

        left = worldOrigin.x;
        right = worldTopRight.x;
        //isInitialized = true;
    }
}
