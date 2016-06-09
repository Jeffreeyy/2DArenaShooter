using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

    private int _lives = 5;

    void OnEnable()
    {
        PlayerHealth.Lives += RemoveLives;
    }

    void RemoveLives()
    {
        if (_lives > 0)
        {
            _lives -= 1;
        }
        else
            Debug.Log("delete player from the game");
    }
}
