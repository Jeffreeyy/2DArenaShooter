using UnityEngine;
using System.Collections;

public class JetpackFuel : MonoBehaviour 
{
    private float _fuel = 200;
    public float Fuel
    {
        get
        {
            return _fuel;
        }
    }
    private float _drainRate = .1f;
    private float _drainAmount = 1.25f;
    private float _rechargeRate = .1f;
    private float _rechargeAmount = 1.2f;

    private bool _isUsingJetpack = false;
    public bool IsUsingJetpack
    {
        get
        {
            return _isUsingJetpack;
        }
        set
        {
            _isUsingJetpack = value;
        }
    }
    private bool _isDrainingFuel = false;
    private bool _isRecharging = true;
    public bool IsRecharging
    {
        set
        {
            _isRecharging = value;
        }
    }
    public bool IsDrainingFuel
    {
        get
        {
            return _isDrainingFuel;
        }
        set
        {
            _isDrainingFuel = value;
        }
    }

    void Update()
    {
        if(_fuel > 0 && !_isDrainingFuel && _isUsingJetpack)
        {
            StartCoroutine(DrainFuel());
        }
        else if(_fuel < 200 && !_isRecharging && !_isUsingJetpack)
        {
            StartCoroutine(RechargeFuel());
        }
    }

    IEnumerator DrainFuel()
    {
        IsDrainingFuel = true;
        while(_isDrainingFuel)
        {
            yield return new WaitForSeconds(_drainRate);
            _fuel -= _drainAmount;
        }
    }

    IEnumerator RechargeFuel()
    {
        _isRecharging = true;
        while(_isRecharging)
        {
            yield return new WaitForSeconds(_rechargeRate);
            _fuel += _rechargeAmount;
        }
    }
}