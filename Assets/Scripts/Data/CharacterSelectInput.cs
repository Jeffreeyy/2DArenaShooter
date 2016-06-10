using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelectInput : MonoBehaviour {
    [SerializeField]private int _playerID;
    public int PlayerID{ get { return _playerID; } }
    [SerializeField]private bool _playerActive;
    public bool PlayerActive{ get { return _playerActive; } }
    [SerializeField]private bool _playerReady;
    public bool PlayerReady { get { return _playerReady; } }
    [SerializeField]private int _currentWeaponIndex;
    [SerializeField]private string[] _weapons;

    private PlayerData _playerData;

    private CharacterSelect _characterSelect;


    [SerializeField]private GameObject _beginPanel;
    private Text _currentWeaponText;

    void Start()
    {
        _playerData = GameObject.Find("DataObject").GetComponent<PlayerData>();
        _characterSelect = GameObject.Find("CharacterSelectManager").GetComponent<CharacterSelect>();
        _currentWeaponText = GameObject.Find("CurrentWeaponText" + _playerID).GetComponent<Text>();
        SetWeaponText();

    }

	void Update () 
    {
        if (!_playerActive)
        {
            if (Input.GetButtonDown("Xbox_Button_A_" + _playerID))
            {
                _playerActive = true;
                _beginPanel.SetActive(false);
                _characterSelect.ActivePlayers++;
            }
        }
        if (_playerActive)
        {
            if (Input.GetButtonDown("Xbox_Button_Y_" + _playerID) && !_playerReady)
            {
                NextWeapon();
            }
            if (Input.GetButtonDown("Xbox_Button_Start_" + _playerID))
            {
                ToggleReady();
                _playerData.SetData(_playerID, _currentWeaponIndex);
            }
        }

	}

    void NextWeapon()
    {
        if(_currentWeaponIndex >= _weapons.Length -1)
        {
            _currentWeaponIndex = 0;
        }
        else
        {
            _currentWeaponIndex++;
        }
        SetWeaponText();
    }

    void ToggleReady()
    {
        _playerReady = !_playerReady;
        if(_playerReady)
        {
            _characterSelect.ReadyPlayers++;
        }
        else if(!_playerReady)
        {
            _characterSelect.ReadyPlayers--;
        }
    }

    void SetWeaponText()
    {
        _currentWeaponText.text = _weapons[_currentWeaponIndex];
    }
}
