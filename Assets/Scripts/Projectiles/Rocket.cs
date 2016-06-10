using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    [SerializeField]private GameObject _rocketDeathParticles;
    [SerializeField]private float _projectileSpeed;
    private ExplosionForce2D _explosionForce2D;

    void OnEnable()
    {
        _explosionForce2D = GameObject.FindWithTag("Player").GetComponent<ExplosionForce2D>();
    }
    
    void Update()
    {
        transform.Translate(Vector2.right * _projectileSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("TakeDamage", 1f);
        }
        DestroyRocket(); 
    }

    void DestroyRocket()
    {
        GameObject deathParticles = ObjectPool.instance.GetObjectForType(_rocketDeathParticles.name, true);
        deathParticles.transform.position = transform.position;
        deathParticles.transform.rotation = transform.rotation;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 10);
        Vector3 explosionPos = Camera.main.ScreenToWorldPoint(pos);
        _explosionForce2D.AddExplosionForce(GetComponent<Rigidbody2D>(), _explosionForce2D.Power * 100, explosionPos, _explosionForce2D.Radius);
        ObjectPool.instance.PoolObject(this.gameObject);
    }
}