using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
    [SerializeField]private float _offset;
    [SerializeField]private Transform _portal1;
    [SerializeField]private Transform _portal2;
	
	void Update () 
    {
	    if(transform.position.x < _portal2.position.x - _offset)
        {
            transform.position = new Vector3(_portal1.position.x, transform.position.y, transform.position.z);
        }
        if(transform.position.x > _portal1.position.x + _offset)
        {
            transform.position = new Vector3(_portal2.position.x, transform.position.y, transform.position.z);
        }
	}
}
