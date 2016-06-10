using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour 
{
    private PlayerData _playerData;
    [SerializeField]private GameObject[] _players;
    private CharacterSelectInput[] _playersInput;
    [SerializeField]private int _activePlayers;
    public int ActivePlayers
    {
        get { return _activePlayers; }
        set { _activePlayers = value; }
    }
    [SerializeField]private int _readyPlayers;
    public int ReadyPlayers
    {
        get { return _readyPlayers; }
        set { _readyPlayers = value; }
    }
	
    void Start()
    {
        _playerData = GameObject.Find("DataObject").GetComponent<PlayerData>();
        _playersInput = new CharacterSelectInput[4];
        for (int i = 0; i < _players.Length; i++)
        {
            _playersInput[i] = _players[i].GetComponent<CharacterSelectInput>();
        }
    }
    
    void Update () 
    {
        CheckForReadyPlayers();
	}

    void CheckForReadyPlayers()
    {
        if(_readyPlayers >= 2 && _readyPlayers == _activePlayers)
        {
            _playerData.PlayerAmount = _readyPlayers;
            Application.LoadLevel(1);
        }
    }
}
