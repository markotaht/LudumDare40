using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAI : MonoBehaviour {

    public GameObject _player;
    public float _speed;
    public float _damage;
    public float _range;
    public float _maxhealth;
    private float _health;

    // Use this for initialization
    void Start () {
        _health = _maxhealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnHit(float damage)
    {
        _health -= damage;
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        if(_health <= 0)
        {
            Die();
        }
        //Update UI
    }

    private void Die() {
        GameManager.instance.DecreaseMobCounter();
    }

}
