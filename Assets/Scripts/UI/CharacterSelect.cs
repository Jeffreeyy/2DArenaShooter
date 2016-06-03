using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{
    private Image _currentCharacter;
    [SerializeField]private Sprite[] _playerSprites;
    private int _playerIndex;
    private int _maxPlayerIndex;
    private int _minPlayerIndex = 1;
	// Use this for initialization
	void Start()
	{
        _currentCharacter = GetComponent<Image>();
        _maxPlayerIndex = _playerSprites.Length - 1;
	}
	
	// Update() is called once per frame
	void Update()
	{
        WhichPlayerImage();

		if(Input.GetKeyDown(KeyCode.Q))
        {
            PreviousCharacterImage();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            NextCharacterImage();
        }
	}

    void WhichPlayerImage()
    {
        switch (_playerIndex)
        {
            case 0:
                _currentCharacter.sprite = _playerSprites[0];
                break;
            case 1:
                _currentCharacter.sprite = _playerSprites[1];
                break;
            case 2:
                _currentCharacter.sprite = _playerSprites[2];
                break;
            case 3:
                _currentCharacter.sprite = _playerSprites[3];
                break;
        }
    }

    public void PreviousCharacterImage()
    {
        if (_playerIndex > _minPlayerIndex)
        {
            _playerIndex--;
        }
        else
        {
            _playerIndex = _maxPlayerIndex;
        }
    }

    public void NextCharacterImage()
    {
        if (_playerIndex < _maxPlayerIndex)
        {
            _playerIndex++;
        }
        else
        {
            _playerIndex = _minPlayerIndex;
        }
    }

    public void SetDefault()
    {
        _currentCharacter.sprite = _playerSprites[1];
    }
}