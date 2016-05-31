using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerCollisionChecker))]
public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]private float _movementSpeed;
    private bool _duck = false;
    public bool Duck
    {
        get
        {
            return _duck;
        }
        set
        {
            _duck = value;
        }
    }
    private Rigidbody _rb;
    private PlayerCollisionChecker _colChecker;
    [SerializeField]private float _jumpSpeed;
    private AudioSource _jumpSound;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _colChecker = GetComponent<PlayerCollisionChecker>();
        _jumpSound = GetComponent<AudioSource>();
    }

    public void JumpUp()
    {
        if (_colChecker.CanJump)
        {
            _rb.velocity = new Vector3(0, _jumpSpeed, 0);
            _jumpSound.pitch = Random.Range(.75f, 1.25f);
            _jumpSound.Play();
        }
    }

    public void MoveLeft()
    {
        if (_colChecker.CanMove(-1))
        {
            _rb.MovePosition(_rb.position + (Vector3.left * _movementSpeed * Time.deltaTime));
        }
    }

    public void MoveRight()
    {
        if (_colChecker.CanMove(1))
        {
            _rb.MovePosition(_rb.position + (Vector3.right * _movementSpeed * Time.deltaTime));
        }
    }

    public void Jetpack()
    {
        _rb.AddForce(Vector3.up * 10, ForceMode.Acceleration);
        Debug.Log(_rb.velocity);
    }
}