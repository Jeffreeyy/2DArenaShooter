using UnityEngine;
using System.Collections;

public class JetpackFuel : MonoBehaviour 
{
    private float _drainRate = .1f;
    private float _drainAmount = 1;
    private float _rechargeRate = .1f;
    private float _rechargeAmount = .2f;
    private float _maxFuel;
    private float _fuel = 100;
    public float Fuel
    {
        get
        {
            return _fuel;
        }
        set
        {
            _fuel = value;
        }
    }

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

    private PlayerJetpack _playerAbilities;

    private bool _isRecharging = false;

    // use this for initialization
    void Start()
    {
        _playerAbilities = GetComponent<PlayerJetpack>();
        _maxFuel = _fuel;
    }

    // Update is called once per frame 
    void Update()
    {
        RechargeFuel();
    }

    private void RechargeFuel()
    {
        if (!_isUsingJetpack && _fuel < _maxFuel && !_isRecharging)
        {
            StartCoroutine(RechargingFuel());
        }
        else if (_isUsingJetpack)
        {
            _isRecharging = false;
        }
    }

    public IEnumerator FuelDrain()
    {
        while (_isUsingJetpack)
        {
            yield return new WaitForSeconds(_drainRate);

            if (_fuel > 0)
            {
                _fuel -= _drainAmount;
            }
            else
                _playerAbilities.DeactivateJetpack();
        }
    }

    IEnumerator RechargingFuel()
    {
        _isRecharging = true;
        while (!_isUsingJetpack)
        {
            yield return new WaitForSeconds(_rechargeRate);
            _fuel += _rechargeAmount;
        }
    }
}