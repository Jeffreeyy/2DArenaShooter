using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour 
{
    [SerializeField]private Image _fuelBar;
    private float _powerOffset;
    private JetpackFuel _jetPackFuel;
    // use this for initialization
    void Start()
    {
        _jetPackFuel = GetComponent<JetpackFuel>();
        _powerOffset = _jetPackFuel.Fuel;
    }

    // Update is called once per frame 
    void Update()
    {
        _fuelBar.fillAmount = _jetPackFuel.Fuel / _powerOffset;
    }
}