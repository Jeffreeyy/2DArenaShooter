using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private int _lives = 5;

    void TakeDamage(int _dmg)
    {
        _lives -= _dmg;

        if (_lives == 0)
        {
            //player dead
        }
    }
}