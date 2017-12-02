using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour {

    public GameObject _player;
    public float _speed;
    public float _damage;
    public float _range;

    //debug:
    private float cd = 3;
    private float cdCounter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, _player.transform.position) > _range)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            //Trigger attack animation
            if (cdCounter <= 0)
            {
                Hit();
                cdCounter = cd;
            }
            else
            {
                cdCounter -= Time.deltaTime;
            }
        }
	}

    void Hit()
    {
        _player.GetComponent<PlayerStats>().OnHit(_damage);
        if(Random.Range(0, 100) < 25)
        {
            _player.GetComponent<PlayerStats>().AddBuff(PlayerStats.Buff.Bleeding);
        }
    }

}
