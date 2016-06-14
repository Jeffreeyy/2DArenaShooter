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
    private float _chargeAndDrainRate = .1f;
    [SerializeField]private float _drainAmount;
    [SerializeField]private float _rechargeAmount;

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
    private bool _isRecharging = true;
    public bool IsRecharging
    {
        set
        {
            _isRecharging = value;
        }
    }
    

    void Update()
    {
        DrainAndRecharge();
    }

    void DrainAndRecharge()
    {
        if (!_isDrainingFuel && _isUsingJetpack)
        {
            StartCoroutine(DrainFuel());
        }
        else if (!_isRecharging && !_isUsingJetpack)
        {
            StartCoroutine(RechargeFuel());
        }

        if (_fuel > 200)
        {
            _fuel = 200;
        }
        else if (_fuel < 0)
        {
            _fuel = 0;
        }
    }

    IEnumerator DrainFuel()
    {
        _isDrainingFuel = true;
        while(_isDrainingFuel)
        {
            yield return new WaitForSeconds(_chargeAndDrainRate);
            _fuel -= _drainAmount;
        }
    }

    IEnumerator RechargeFuel()
    {
        _isRecharging = true;
        while(_isRecharging)
        {
            yield return new WaitForSeconds(_chargeAndDrainRate);
            _fuel += _rechargeAmount;
        }
    }
}