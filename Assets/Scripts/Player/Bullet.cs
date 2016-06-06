using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]private float _projectileSpeed;
    private AudioSource _shootSound;
    [SerializeField]private GameObject _deathParticles;
	
    void Start()
    {
        _shootSound = GameObject.Find("Gun").GetComponent<AudioSource>();
        _shootSound.pitch = Random.Range(.75f, 1.25f);
        _shootSound.Play();
    }

	void Update () 
    {
        transform.Translate(Vector2.right * _projectileSpeed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("TakeDamage", 1f);
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        //PlayParticles();
        Instantiate(_deathParticles, transform.position, Quaternion.identity);
    }
}
