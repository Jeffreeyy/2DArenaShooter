using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField]private Transform[] _muzzles;
    [SerializeField]private GameObject _pellet;
    private string _weaponName = "Shotgun";
    public string WeaponName
    {
        get
        {
            return _weaponName;
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < _muzzles.Length; i++)
        {
            GameObject bullet = ObjectPool.instance.GetObjectForType(_pellet.name, true);
            bullet.transform.position = _muzzles[i].position;
            bullet.transform.rotation = _muzzles[i].rotation;
        }
    }
}