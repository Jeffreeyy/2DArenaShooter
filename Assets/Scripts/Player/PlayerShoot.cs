using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]private GameObject _bullet;
    [SerializeField]private Transform _muzzle;
    [SerializeField]private float _reloadTime;
    [SerializeField]private float _knockbackAmount;
    public bool canShoot = true;
    private Rigidbody _playerRigidbody;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    public IEnumerator Shoot()
    {
        Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
        Knockback();
        canShoot = false;
        yield return new WaitForSeconds(_reloadTime);
        canShoot = true;
    }

    private void Knockback()
    {
        Vector3 direction = transform.position - _muzzle.position;
        _playerRigidbody.AddForce(direction * _knockbackAmount, ForceMode.Impulse);
    }

}
