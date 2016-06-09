using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour 
{
    [SerializeField]private GameObject[] _players;
    private CharacterSelectInput[] _playersInput;
    [SerializeField]private Button[] _player1Weapons;
    [SerializeField]private Button[] _player2Weapons;
    [SerializeField]private Button[] _player3Weapons;
    [SerializeField]private Button[] _player4Weapons;
	
    void Start()
    {
        _playersInput = new CharacterSelectInput[4];
        for (int i = 0; i < _players.Length; i++)
        {
            _playersInput[i] = _players[i].GetComponent<CharacterSelectInput>();
        }
    }
    
    void Update () 
    {
        CheckForActivePlayers();
	}

    void CheckForActivePlayers()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            if (_playersInput[i].PlayerActive)
            {
                //Debug.Log("Controller: " + _playersInput[i].PlayerID + " is Active!");
            }
        }
    }
}
