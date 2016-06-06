using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private int _lives;

    void TakeDamage(int _dmg)
    {
        _lives -= _dmg;

        if (_lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}