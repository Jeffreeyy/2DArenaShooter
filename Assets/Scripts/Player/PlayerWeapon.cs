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
    private IWeapon[] _weapons;
	// Use this for initialization
	void Start()
	{
        _weapons = GetComponents<IWeapon>();
	}
}