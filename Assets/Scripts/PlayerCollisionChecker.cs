using UnityEngine;
using System.Collections;

public class PlayerCollisionChecker : MonoBehaviour 
{
    private PlayerMovement _movement;
    [SerializeField]private bool _canJump = false;
    public bool CanJump
    {
        get
        {
            return _canJump;
        }
    }
    [SerializeField]private bool _canMove;

    private bool _canDisableCol = false;

    [SerializeField]private float _raycastRange;
    private Collision _collidingObject;

    void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        CanMove(-1);
        CanMove(1);
        if(_movement.Duck && _canDisableCol)
        {
            StartCoroutine(DisableGroundCollision(_collidingObject, 0.15f));
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform")
        {
            _canJump = true;
        }
        if (col.gameObject.tag == "Platform")
        {
            _canDisableCol = true;
            _collidingObject = col;

        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform")
        {
            _canJump = true;
        }
    }

    void OnCollisionExit()
    {
        _canJump = false;
    }

    public bool CanMove(int dir)
    {
        float yOffset = 0.05f;
        for(int i = 0; i < 3; i ++)
        {
            float y = -yOffset + (yOffset * i);
            Vector3 rayOrigin = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);
            Ray ray = new Ray(rayOrigin, new Vector3(dir, 0f, 0f));
            Debug.DrawRay(ray.origin, ray.direction * _raycastRange);
            if (Physics.Raycast(ray, _raycastRange, 1 << 9))
            {
                _canMove = false;
            }
            else
            {
                _canMove = true;
            }

        }
        return _canMove;
    }

    IEnumerator DisableGroundCollision(Collision col,float sec)
    {
        col.collider.enabled = false;
        Debug.Log("Disabling Collision...");
        yield return new WaitForSeconds(sec);
        _movement.Duck = false;
        _canDisableCol = false;
        col.collider.enabled = true;
        Debug.Log("Collision Enabled!");
    }
}
