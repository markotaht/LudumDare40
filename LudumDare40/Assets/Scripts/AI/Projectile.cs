using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private GameObject _target;
    private float _damage;
    public float _speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_target != null)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
            }
            else
            {
                _target.GetComponent<PlayerStats>().OnHit(_damage);
                Destroy(gameObject);
            }
        }
	}

    public void Shoot(GameObject player, float damage)
    {
        _target = player;
        _damage = damage;
        if (Random.Range(0, 100) < 10)
        {
            _target.GetComponent<PlayerStats>().AddBuff(PlayerStats.Buff.Slowed);
        }
    }

}
