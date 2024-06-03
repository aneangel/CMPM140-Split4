using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController1 : MonoBehaviour
{
    [SerializeField] private GameObject button1, button2, platform1, platform2;

    void FixedUpdate()
    {
        var button1Script = button1.GetComponent<ButtonController>(); //Accessing Button Controller Script of buttons
        var button2Script = button2.GetComponent<ButtonController>();
        
        if(button1Script.isPressed() == true && button2Script.isPressed() == true){ //If both buttons are active...
            var platform1Script = platform1.GetComponent<MovingPlatformController>(); //Accessing Moving Platform Controller
            var platform2Script = platform2.GetComponent<MovingPlatformController>();
            
            platform1Script.UpdatePlatformPosition(); //Call Update position script
            platform2Script.UpdatePlatformPosition();
        }
    }
}
