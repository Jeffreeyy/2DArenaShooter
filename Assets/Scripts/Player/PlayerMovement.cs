using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 10f;
    private Rigidbody2D _rb2d;
    private PlayerGroundCollisionChecker2D _cc2d;
    private PlayerShoot _shoot;
    private AudioSource _jumpSound;

    private int ControllerID { get; set; }

    void Awake()
    {
        _shoot = GetComponent<PlayerShoot>();
        _rb2d = GetComponent<Rigidbody2D>();
        _cc2d = GetComponent<PlayerGroundCollisionChecker2D>();
        _jumpSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        float x = Input.GetAxis("Xbox_JoystickLeft_X_1");
        _rb2d.velocity = new Vector2(x * _speed, _rb2d.velocity.y);
        if (Input.GetButtonDown("Xbox_LB_1") && _cc2d.CanJump)
        {
            _rb2d.velocity = new Vector2(0, 25f);
            _jumpSound.pitch = Random.Range(.75f, 1.25f);
            _jumpSound.Play();
        }

        if (Input.GetAxis("Xbox_RT_1") > 0.25f)
        {
            if (_shoot.canShoot)
            {
                StartCoroutine(_shoot.Shoot());
            }
        }

        if (Input.GetAxis("Xbox_LT_1") > 0.25f)
        {
            //_movement.Jetpack();
            Debug.Log("PRESSING LEFT TRIGGER");
            _rb2d.AddForce(Vector2.up * Input.GetAxis("Xbox_LT_1") * 100, ForceMode2D.Force);
        }
    }
}
