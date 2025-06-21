
using UnityEngine;

public class Initiliazer : MonoBehaviour
{
    void Awake()
    {

        Screen.fullScreen = true;
        ScreenManager.Init();
    }
}
