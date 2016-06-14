using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    private PlayerGroundCollisionChecker2D _cc2d;
    private PlayerMovement _playerMovement;
	// Use this for initialization
	void Start()
	{
		_cc2d = GetComponent<PlayerGroundCollisionChecker2D>();
        _playerMovement = GetComponent<PlayerMovement>();
	}
	
	// Update() is called once per frame
	void Update()
	{
        if (Input.GetButtonDown("Xbox_LB_" + _playerMovement.PlayerID) && _cc2d.CanJump)
        {
            _playerMovement.Jump();
        }

        if (Input.GetAxis("Xbox_RT_" + _playerMovement.PlayerID) > 0.25f)
        {
            _playerMovement.Shoot();
        }

        if (Input.GetAxis("Xbox_LT_" + _playerMovement.PlayerID) > 0.25f)
        {
            _playerMovement.Jetpack();
        }
	}
}