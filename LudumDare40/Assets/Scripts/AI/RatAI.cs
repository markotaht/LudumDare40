using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour {

    public GameObject Player;
    public float _speed;
    public float _damage;

    //debug:
    private float cd = 3;
    private float cdCounter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, Player.transform.position) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, _speed * Time.deltaTime);
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
        Player.GetComponent<PlayerStats>().OnHit(_damage);
    }

}
