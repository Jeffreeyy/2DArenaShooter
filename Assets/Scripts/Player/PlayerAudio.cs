using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {

    public delegate void PlaySound();
    PlaySound soundDelegate;

    void Update()
    {
        if(soundDelegate != null)
        {
            
        }
    }

}
