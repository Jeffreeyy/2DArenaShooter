﻿using UnityEngine;
using System.Collections;

public class PlayerAim : MonoBehaviour 
{
	void Update () 
    {
        float rX = Input.GetAxisRaw("Xbox_JoystickRight_4th_1");
        float rY = Input.GetAxisRaw("Xbox_JoystickRight_5th_1");

        if (rX != 0.0f || rY != 0.0f)
        {
            float angle = Mathf.Atan2(rY, rX) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), 0.2f);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 0.1f);
        }
	}
}
