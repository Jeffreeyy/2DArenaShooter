using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]private float _projectileSpeed;
    private AudioSource _shootSound;
    [SerializeField]private GameObject _deathParticles;
	
    void Start()
    {
        _shootSound = GetComponent<AudioSource>();
        _shootSound.pitch = Random.Range(.75f, 1.25f);
    }

	void Update () 
    {
        transform.Translate(Vector3.right * _projectileSpeed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "Ground" || col.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        //PlayParticles();
        Instantiate(_deathParticles, transform.position, Quaternion.identity);
    }
}
