﻿using UnityEngine;
using System.Collections;

public class Explosion2D : MonoBehaviour
{
    [SerializeField]private float _explosionDelay = .01f;
    [SerializeField]private float _explosionRate = 1;
    [SerializeField]private float _maxExplosionSize = 10;
    [SerializeField]private float _explosionModifier = 10;
    [SerializeField]private float _currentRadius = 0;
    private float _oldExplosionRadius;

    private Rigidbody2D _targetRigidBody2D;
    private CircleCollider2D _explosionRadius;

    private bool _isExploded = false;
	// Use this for initialization
	void Start()
	{
        _explosionRadius = GetComponent<CircleCollider2D>();
        _oldExplosionRadius = _explosionRadius.radius;
	}

    void OnEnable()
    {
        _explosionDelay = .01f;
    }
	
	// Update() is called once per frame
	void FixedUpdate()
	{
        _explosionDelay -= Time.deltaTime;
        if(_explosionDelay < 0)
        {
            _isExploded = true;
        }

        if(_isExploded)
        {
            if(_currentRadius < _maxExplosionSize)
            {
                _currentRadius += _explosionRate;
            }
            
            _explosionRadius.radius = _currentRadius;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        _targetRigidBody2D = col.gameObject.GetComponent<Rigidbody2D>();
        if(_isExploded)
        {
            if(_targetRigidBody2D != null)
            {
                Vector2 target = col.gameObject.transform.position;
                Vector2 bomb = gameObject.transform.position;
                Vector2 direction = _explosionModifier * (bomb - target);
                _targetRigidBody2D.AddForce(direction);
            }
        }
    }
}