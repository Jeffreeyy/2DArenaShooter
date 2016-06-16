using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Win_Loss : MonoBehaviour
{
    private GameObject[] _players;
    private int _playerID;
	// Use this for initialization
	void Start()
	{
        _players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update() is called once per frame
	void Update()
	{
		if(_players.Length <= 1)
        {
            _playerID = _players[0].GetComponent<PlayerMovement>().PlayerID;
            PlayerPrefs.SetInt("PlayerWon", _playerID);
            SceneManager.LoadScene(SceneNames.VICTORYSCENE);
        }
	}
}