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


    [SerializeField]private GameObject _beginPanel;
    private int _currentWeaponIndex;

    void Start()
    {
        NextWeapon();
    }

	void Update () 
    {
        if (!_playerActive)
        {
            if (Input.GetButtonDown("Xbox_Button_A_" + _playerID))
            {
                Debug.Log("Controller " + _playerID + " pressed A");
                _playerActive = true;
                _beginPanel.SetActive(false);
            }
        }
        if (_playerActive)
        {
            if (Input.GetButtonDown("Xbox_Button_Y_" + _playerID))
            {
                Debug.Log("Controller " + _playerID + " pressed Y");
                //NextWeapon();
                Debug.Log(_currentWeaponIndex);

            }
        }
	}
    /*private void NextWeapon()
    {
        if (_currentWeaponIndex == _weaponStrings.Length - 1)
        {
            _currentWeaponIndex = 0;
        }
        else
        {
            _currentWeaponIndex++;
        }
        _currentWeaponString = _weaponStrings[_currentWeaponIndex];
        _currentWeaponText.text = _currentWeaponString;
    }*/
}
