using UnityEngine;
using System.Collections;

public class Machinegun : MonoBehaviour, IWeapon
{
    [SerializeField]private Transform _muzzle;
    [SerializeField]private GameObject _bullet;
    private string _weaponName = "MachineGun";
    public string WeaponName
    {
        get
        {
            return _weaponName;
        }
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetObjectForType(_bullet.name, true);
        bullet.transform.position = _muzzle.transform.position;
        bullet.transform.rotation = _muzzle.transform.rotation;
    }
}