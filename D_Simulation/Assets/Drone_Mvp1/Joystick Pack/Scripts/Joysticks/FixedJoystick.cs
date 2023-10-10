using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoystick : Joystick
{
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        base.OnPointerUp(null);
    }
}