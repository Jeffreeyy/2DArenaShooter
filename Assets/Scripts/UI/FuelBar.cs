using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour 
{
    [SerializeField]private Image _fuelBar;
    private float _fuelOffset;
    private PlayerHealth _jetPackFuel;
    // use this for initialization
    void Start()
    {
        _jetPackFuel = GetComponent<PlayerHealth>();
        _fuelOffset = _jetPackFuel.Health;
    }

    // Update is called once per frame 
    void Update()
    {
        _fuelBar.fillAmount = _jetPackFuel.Health / _fuelOffset;
    }
}