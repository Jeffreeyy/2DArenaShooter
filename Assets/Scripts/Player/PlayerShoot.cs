using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    //[SerializeField]private GameObject _bullet;
    //[SerializeField]private Transform _muzzle;
    

    /*public Transform Muzzle
    {
        get
        {
            return _muzzle;
        }
    }*/
    [SerializeField]private Transform _gun;

    [SerializeField]private float _reloadTime;
    [SerializeField]private float _knockbackAmount;

    private bool _canShoot = true;

    private Rigidbody2D _playerRigidbody;
    private AudioSource _shootSound;
    private PlayerWeapon _playerWeapon;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _shootSound = _gun.GetComponent<AudioSource>();
        _playerWeapon = GetComponent<PlayerWeapon>();
    }

    public IEnumerator Shoot()
    {
        if (_canShoot)
        {
            //Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
            /*GameObject bullet = ObjectPool.instance.GetObjectForType(_bullet.name, true);
            bullet.transform.position = _muzzle.position;
            bullet.transform.rotation = _muzzle.rotation;*/
            _playerWeapon.CurrentWeapon.Shoot();

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
        Vector3 direction = transform.position - _gun.position;
        _playerRigidbody.AddForce(direction * _knockbackAmount, ForceMode2D.Impulse);
    }

}
