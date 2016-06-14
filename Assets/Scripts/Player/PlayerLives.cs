using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

    private ParticleSystem _particles;
    private LifeImage lifeImage;
    [SerializeField]private int _lives = 5;
    private Vector3 _spawnPosition;
    public Vector3 SpawnPosition
    {
        get{ return _spawnPosition; }
        set{ _spawnPosition = value; }
    }

    void Awake()
    {
        _particles = GetComponentInChildren<ParticleSystem>();
        lifeImage = GetComponent<LifeImage>();
    }

    public void RemoveLives()
    {
        if (_lives > 0)
        {
            lifeImage.CutLives();
            StartCoroutine(Respawn());
            _lives -= 1;
        }
        else
        {
            Destroy(this.gameObject);
        }    
    }

    IEnumerator Respawn()
    {
        _particles.Play();
        yield return new WaitForSeconds(0.3f);
        transform.position = _spawnPosition;
    }
}
