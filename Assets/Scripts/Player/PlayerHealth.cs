using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private int _health;

    public delegate void PlayerLivesDelegate();
    public static event PlayerLivesDelegate Lives;

    void TakeDamage(int _dmg)
    {
        _health -= _dmg;

        if (_health <= 0)
        {
            if (Lives != null)
            {
                Lives();
                _health = 60;
            }
        }
    }

}