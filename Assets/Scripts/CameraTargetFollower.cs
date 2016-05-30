using UnityEngine;
using System.Collections;

public class CameraTargetFollower : MonoBehaviour 
{
    [SerializeField]private Transform _target;
    [SerializeField]private float _damping;
    [SerializeField]private Vector3 _offset;
    private float _newYPos;
    private Vector3 _newPos;
	
	void LateUpdate () 
    {
        _newPos = new Vector3(0f, _newYPos, -10f);
        transform.position = Vector3.Lerp(transform.position, _newPos, _damping * Time.deltaTime);

        if (_target.position.y > _offset.y)
        {
            _newYPos = _target.position.y;
        }
        else
        {
            _newYPos = _offset.y;
        }
	}
}
