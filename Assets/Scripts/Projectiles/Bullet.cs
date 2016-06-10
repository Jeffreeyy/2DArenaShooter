using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    [SerializeField]private GameObject _deathParticles;
    [SerializeField]private float _projectileSpeed;

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
        ObjectPool.instance.PoolObject(this.gameObject);
    }

    void OnDisable()
    {
        //PlayParticles();
        //Instantiate(_deathParticles, transform.position, Quaternion.identity);
    }
}
