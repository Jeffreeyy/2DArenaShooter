using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [SerializeField]private float _projectileSpeed;
    private AudioSource _shootSound;
	
    void Start()
    {
        Destroy(this.gameObject, 2.5f);
        _shootSound = GetComponent<AudioSource>();
        _shootSound.pitch = Random.Range(.75f, 1.25f);
    }

	// Update is called once per frame
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
    }
}
