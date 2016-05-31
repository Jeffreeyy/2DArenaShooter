using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour 
{
    private PlayerMovement _movement;
<<<<<<< HEAD
    private PlayerJetpack _playerJetpack;
    private JetpackFuel _jetpackFuel;
=======
    private PlayerAbilities _abilities;
    private PlayerPower _playerPower;
    private PlayerShoot _playerShoot;
>>>>>>> origin/master

    void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
<<<<<<< HEAD
        _playerJetpack = GetComponent<PlayerJetpack>();
        _jetpackFuel = GetComponent<JetpackFuel>();
=======
        _abilities = GetComponent<PlayerAbilities>();
        _playerPower = GetComponent<PlayerPower>();
        _playerShoot = GetComponent<PlayerShoot>();
>>>>>>> origin/master
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
        if (Input.GetKey(KeyCode.Mouse0))
        {
<<<<<<< HEAD
            _playerJetpack.ActivateJetpack();
=======
            _movement.Jetpack();
>>>>>>> origin/master
        }
        else
            _playerJetpack.DeactivateJetpack();
        //ABILITY 2
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
<<<<<<< HEAD
            //_playerJetpack.Punch();
=======
            if (_playerShoot.canShoot)
            {
                StartCoroutine(_playerShoot.Shoot());
            }
        }

        if(!Input.anyKey && !Input.anyKeyDown)
        {
            _playerPower.IsStandingStill = true;
        }
        else
        {
            _playerPower.IsStandingStill = false;
>>>>>>> origin/master
        }
	}
}
