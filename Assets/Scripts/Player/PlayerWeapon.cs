using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
    private IWeapon _currentWeapon;
    public IWeapon CurrentWeapon
    {
        get
        {
            return _currentWeapon;
        }
        set
        {
            _currentWeapon = value;
        }
    }

    private int _currentWeaponIndex;
    private IWeapon[] _weapons;
	// Use this for initialization
	void Start()
	{
        _weapons = GetComponents<IWeapon>();
#if(UNITY_EDITOR)
        _currentWeaponIndex = 2;
#endif
    }

    void Update()
    {
        CheckWhichWeapon();
    }

    void CheckWhichWeapon()
    {
        switch (_currentWeaponIndex)
        {
            case 0:
                _currentWeapon = _weapons[0];
                //shotgun
                break;
            case 1:
                _currentWeapon = _weapons[1];
                //machinegun
                break;
            case 2:
                _currentWeapon = _weapons[2];
                //rocketlauncher
                break;
        }
    }
}