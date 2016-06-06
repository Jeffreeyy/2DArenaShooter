using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour 
{
    private bool _player1Active;
    private bool _player2Active;
    private bool _player3Active;
    private bool _player4Active;

    [SerializeField]private Button[] _player1Weapons;
    [SerializeField]private Button[] _player2Weapons;
    [SerializeField]private Button[] _player3Weapons;
    [SerializeField]private Button[] _player4Weapons;

	void Update () 
    {
        WaitForInput();
	}

    void WaitForInput()
    {
        if (Input.GetButtonDown("Xbox_Button_A_1"))
        {
            _player1Active = true;
        }
        if (Input.GetButtonDown("Xbox_Button_A_2"))
        {
            _player2Active = true;
        }
        if (Input.GetButtonDown("Xbox_Button_A_3"))
        {
            _player3Active = true;
        }
        if (Input.GetButtonDown("Xbox_Button_A_4"))
        {
            _player4Active = true;
        }
    }
}
