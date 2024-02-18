using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlipper : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the A button on the right-hand controller is pressed
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            pageFlip();
        }
    }

    // Define the pageFlip function
    void pageFlip()
    {
        // Page flip logic goes here
        Debug.Log("Page flipped!");
    }
}