using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationController : MonoBehaviour
{
    private void Start()
    {
        Vibration.Init();
    }

    public static void VibrationKnife() 
    {
        Vibration.Vibrate();
    }

    public static void VibrationLog() 
    {
        Vibration.VibratePop();
    }
}
