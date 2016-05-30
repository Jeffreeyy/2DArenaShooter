using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]private GameObject _bullet;
    [SerializeField]private Transform _barrel;
    [SerializeField]private float reloadTime;
    public bool canShoot = true;

    public IEnumerator Shoot()
    {
        Instantiate(_bullet, _barrel.position, _barrel.rotation);
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }

}
