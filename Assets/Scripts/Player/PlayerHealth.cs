using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private float _health = 60;

    public delegate void PlayerLivesDelegate();
    public static event PlayerLivesDelegate Lives;

    /*void OnCollisonEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            TakeDamage(coll.gameObject.GetComponent<ProjectileDamage>()._damage);
        }
    }*/

    void TakeDamage(float _dmg)
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