using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    private ParticleSystem _particles;
    private GameObject _player;
    private PlayerLives _playerLives;
    private bool _isDead = false;
    public bool IsDead
    {
        set { _isDead = value; }
    }
    
	// Use this for initialization
	void Start()
	{
        _particles = GetComponentInChildren<ParticleSystem>();
        _player = transform.GetChild(0).gameObject;
        _playerLives = _player.GetComponent<PlayerLives>();
	}

    void Update()
    {
        if(_isDead)
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        _isDead = false;
        Debug.Log("Setinactive");
        _player.SetActive(false);
        yield return new WaitForSeconds(1f);
        Debug.Log("setactive");
        _player.SetActive(true);
        _particles.Play();
        _player.transform.position = _playerLives.SpawnPosition;
    }
}