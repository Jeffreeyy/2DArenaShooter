using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 60;

    public delegate void PlayerLivesDelegate();
    public static event PlayerLivesDelegate Lives;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Bullet")
        {
            TakeDamage(coll.GetComponent<ProjectileDamage>()._damage);
        }
    }

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