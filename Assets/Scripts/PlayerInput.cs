using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour 
{
    private PlayerMovement _movement;
    private PlayerJetpack _playerJetpack;
    private JetpackFuel _jetpackFuel;

    void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _playerJetpack = GetComponent<PlayerJetpack>();
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
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _playerJetpack.ActivateJetpack();
        }
        else
            _playerJetpack.DeactivateJetpack();
        //ABILITY 2
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //_playerJetpack.Punch();
        }
	}
}
