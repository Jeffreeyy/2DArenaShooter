using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
    [SerializeField]private float _offset;
    private GameObject _portal1;
    private GameObject _portal2;
	
    void Start()
    {
        _portal1 = GameObject.Find("Portal1").gameObject;
        _portal2 = GameObject.Find("Portal2").gameObject;
    }

	void Update () 
    {
	    if(this.transform.position.x > _portal2.transform.position.x - _offset)
        {
            this.transform.position = new Vector3(_portal1.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        if(this.transform.position.x < _portal1.transform.position.x + _offset)
        {
            this.transform.position = new Vector3(_portal2.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
	}
}
