using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    [SerializeField]private GameObject _bullet;
    [SerializeField]private Transform _muzzle;
    private AudioSource _shootSound;

    public Transform Muzzle
    {
        get
        {
            return _muzzle;
        }
    }
    [SerializeField]private float _reloadTime;
    [SerializeField]private float _knockbackAmount;
    private bool _canShoot = true;
    private Rigidbody2D _playerRigidbody;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _shootSound = GameObject.Find("Gun").GetComponent<AudioSource>();
    }

    public IEnumerator Shoot()
    {
        if (_canShoot)
        {
            //Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
            GameObject bullet = ObjectPool.instance.GetObjectForType(_bullet.name, true);
            bullet.transform.position = _muzzle.position;
            bullet.transform.rotation = _muzzle.rotation;

            _shootSound.pitch = Random.Range(.75f, 1.25f);
            _shootSound.Play();

            Knockback();
            _canShoot = false;
            yield return new WaitForSeconds(_reloadTime);
            _canShoot = true;
        }
    }

    private void Knockback()
    {
        Vector3 direction = transform.position - _muzzle.position;
        _playerRigidbody.AddForce(direction * _knockbackAmount, ForceMode2D.Impulse);
    }

}
