using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour
{
    private Transform[] _muzzles;
    [SerializeField]private Transform _bullet;
	// Use this for initialization
	void Start()
	{
        _muzzles = GetComponentsInChildren<Transform>();
	}
	
	// Update() is called once per frame
	void Update()
	{
		
    }

    void Shoot()
    {
        for (int i = 0; i < _muzzles.Length; i++)
        {
            GameObject bullet = ObjectPool.instance.GetObjectForType(_bullet.name, true);
            bullet.transform.position = _muzzles[i].transform.position;
            bullet.transform.rotation = _muzzles[i].transform.rotation;
        }
    }
}