using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]private GameObject _bullet;
    [SerializeField]private Transform _muzzle;
    [SerializeField]private float _reloadTime;
    public bool canShoot = true;

    public IEnumerator Shoot()
    {
        Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
        canShoot = false;
        yield return new WaitForSeconds(_reloadTime);
        canShoot = true;
    }

}
