using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]private GameObject _bullet;
    [SerializeField]private Transform _muzzle;
    [SerializeField]private float _reloadTime;
    [SerializeField]private float _knockbackAmount;
    private bool _canShoot = true;
    private Rigidbody2D _playerRigidbody;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    public IEnumerator Shoot()
    {
        if (_canShoot)
        {
            Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
            Knockback();
            _canShoot = false;
            Debug.Log("ayy");
            yield return new WaitForSeconds(_reloadTime);
            Debug.Log("ayy");
            _canShoot = true;
        }
    }

    private void Knockback()
    {
        Vector3 direction = transform.position - _muzzle.position;
        _playerRigidbody.AddForce(direction * _knockbackAmount, ForceMode2D.Impulse);
    }

}
