﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour 
{
    private PlayerMovement _movement;
    private PlayerShoot _playerShoot;
    private JetpackFuel _jetpackFuel;

    void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _playerShoot = GetComponent<PlayerShoot>();
        _jetpackFuel = GetComponent<JetpackFuel>();
    }

	void Update () 
    {
        //UP
	    if (Input.GetKeyDown(KeyCode.W))
        {
            _movement.JumpUp();
        }
        //DOWN
        if (Input.GetKeyDown(KeyCode.S))
        {
            _movement.Duck = true;
        }
        //LEFT
        if (Input.GetKey(KeyCode.A))
        {
            _movement.MoveLeft();
        }
        //RIGHT
        if (Input.GetKey(KeyCode.D))
        {
            _movement.MoveRight();
        }
        //ABILITY 1
        if (Input.GetKey(KeyCode.Mouse1) && _jetpackFuel.Fuel > 0)
        {
            _movement.Jetpack();
            _jetpackFuel.IsUsingJetpack = true;
            _jetpackFuel.IsRecharging = false;
        }
        else
        {
            _jetpackFuel.IsUsingJetpack = false;
            _jetpackFuel.IsDrainingFuel = false;
        }
        //ABILITY 2
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (_playerShoot.canShoot)
            {
                StartCoroutine(_playerShoot.Shoot());
            }
        }
	}
}
