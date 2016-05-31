using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerJetpack : MonoBehaviour 
{
    private JetpackFuel _jetpackFuel;
    private PlayerMovement _movement;

    void Start()
    {
        _jetpackFuel = GetComponent<JetpackFuel>();
        _movement = GetComponent<PlayerMovement>();
    }

    public void ActivateJetpack()
    {
        if (_jetpackFuel.Fuel > 2 && !_jetpackFuel.IsUsingJetpack)
        {
            _jetpackFuel.IsUsingJetpack = true;
            StartCoroutine(_jetpackFuel.FuelDrain());
            _movement.Jetpack();
        }
    }

    public void DeactivateJetpack()
    {
        _jetpackFuel.IsUsingJetpack = false;
    }
}
