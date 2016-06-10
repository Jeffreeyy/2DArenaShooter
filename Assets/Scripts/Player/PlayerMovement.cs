using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private int _playerID;
    public int PlayerID
    {
        set { _playerID = value; }
    }
    private float _speed = 10f;
    private Rigidbody2D _rb2d;
    private PlayerGroundCollisionChecker2D _cc2d;
    private PlayerShoot _shoot;
    private AudioSource _jumpSound;

    void Awake()
    {
        _shoot = GetComponent<PlayerShoot>();
        _rb2d = GetComponent<Rigidbody2D>();
        _cc2d = GetComponent<PlayerGroundCollisionChecker2D>();
        _jumpSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        float x = Input.GetAxis("Xbox_JoystickLeft_X_" + _playerID);
        _rb2d.velocity = new Vector2(x * _speed, _rb2d.velocity.y);
        if (Input.GetButtonDown("Xbox_LB_" + _playerID) && _cc2d.CanJump)
        {
            _rb2d.velocity = new Vector2(0, 25f);
            _jumpSound.pitch = Random.Range(.75f, 1.25f);
            _jumpSound.Play();
        }

        if (Input.GetAxis("Xbox_RT_" + _playerID) > 0.25f || Input.GetKey(KeyCode.Mouse0))
        {
                StartCoroutine(_shoot.Shoot());
        }

        if (Input.GetAxis("Xbox_LT_" + _playerID) > 0.25f)
        {
            _rb2d.AddForce(Vector2.up * Input.GetAxis("Xbox_LT_" + _playerID) * 100, ForceMode2D.Force);
        }
    }
}
