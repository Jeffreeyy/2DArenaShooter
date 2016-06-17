﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private float _health = 100;
    public float PHealth
    {
        get
        {
            return _health;
        }
    }
    private PlayerLives _playerLives;

    void Start()
    {
        _playerLives = GetComponent<PlayerLives>();
    }

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
            _playerLives.RemoveLives();
           _health = 100;
        }
    }

}