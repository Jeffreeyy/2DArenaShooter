using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour {

    [SerializeField]private float _destoryTime;

	void Start () 
    {
        //Destroy(this.gameObject, _destoryTime);
        ObjectPool.instance.PoolObject(this.gameObject);
	}
}
