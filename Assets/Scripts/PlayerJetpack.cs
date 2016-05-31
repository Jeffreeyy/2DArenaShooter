﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerJetpack : MonoBehaviour 
{
    private JetpackFuel _jetpackFuel;
    //private PlayerMovement _movement;
    //[SerializeField]private float _normalMoveSpeed;
    //[SerializeField]private float _enhancedMoveSpeed;
    //private ParticleSystem[] _particleSystem;
    //[SerializeField]private float _castRange;

    void Start()
    {
        _jetpackFuel = GetComponent<JetpackFuel>();
        //_particleSystem = GetComponentsInChildren<ParticleSystem>();
        //_movement = GetComponent<PlayerMovement>();
        //_normalMoveSpeed = _movement.MovementSpeed;
    }

    public void ActivateJetpack()
    {
        if (_jetpackFuel.Fuel > 2 && !_jetpackFuel.IsUsingJetpack)
        {
            _jetpackFuel.IsUsingJetpack = true;
            StartCoroutine(_jetpackFuel.FuelDrain());
            //EmitParticles(true);
            //_movement.MovementSpeed = _enhancedMoveSpeed;
        }
    }

    public void DeactivateJetpack()
    {
        _jetpackFuel.IsUsingJetpack = false;
        //EmitParticles(false);
        //_movement.MovementSpeed = _normalMoveSpeed;
    }

    /*private void EmitParticles(bool activate)
    {
        for (int i = 0; i < _particleSystem.Length; i++)
        {
            var em = _particleSystem[i].emission;
            em.enabled = activate;
        }
    }*/

    

    /*public void Punch()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector2.right));
        RaycastHit hit = new RaycastHit();
        if(Physics.Raycast(ray, out hit, _castRange))
        {
            if(hit.transform.tag == "Enemy")
            {
                hit.collider.SendMessageUpwards("TakeDamage", 10f);
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(_castRange, 0)), Color.yellow, 0.4f);
    }*/
}
