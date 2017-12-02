﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    [SerializeField] public float _speed;
    [SerializeField] public float _damage;
    [SerializeField] public float _health;

    public void OnHit(float damage)
    {
        _health -= damage;
        Debug.Log("Hit, health=" + _health);
    }

}
