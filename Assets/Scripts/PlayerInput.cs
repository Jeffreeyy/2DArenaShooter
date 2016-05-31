using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour 
{
    private PlayerMovement _movement;
    private PlayerJetpack _playerJetpack;
    private PlayerShoot _playerShoot;

    void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _playerJetpack = GetComponent<PlayerJetpack>();
        _playerShoot = GetComponent<PlayerShoot>();
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
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Mouse0))
=======
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _playerJetpack.ActivateJetpack();
            _movement.Jetpack();
        }
        else
            _playerJetpack.DeactivateJetpack();
        //ABILITY 2
        if (Input.GetKeyDown(KeyCode.Mouse1))
>>>>>>> origin/master
        {
            //_playerJetpack.Punch();
            if (_playerShoot.canShoot)
            {
                StartCoroutine(_playerShoot.Shoot());
            }
        }
<<<<<<< HEAD
        //ABILITY 2
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _movement.Jetpack();
        }

        if(!Input.anyKey && !Input.anyKeyDown)
        {
            _playerPower.IsStandingStill = true;
        }
        else
        {
            _playerPower.IsStandingStill = false;
        }
=======
>>>>>>> origin/master
	}
}
