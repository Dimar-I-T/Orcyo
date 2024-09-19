using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    public GameObject pressedImage;
    private bool Pressed = false;

    public void Update()
    {
        if (Pressed)
        {
            pressedImage.SetActive(true);
        }
        else if (!Pressed)
        {
            pressedImage.SetActive(false);
        }
    }

    public void PressedButton()
    {
        Pressed = true;
    }

    public void NotPressed()
    {
        Pressed = false;
    }
}
