﻿using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

    [SerializeField]private int _lives = 5;

    public void RemoveLives()
    {
        if (_lives > 0)
        {
            _lives -= 1;
        }
        else
        {
            Debug.Log("delete player from the game");
            Destroy(this.gameObject);
        }
            
    }
}
