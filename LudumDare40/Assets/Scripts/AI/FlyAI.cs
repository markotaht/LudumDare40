using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAI : AbstractAI {

    public GameObject _projectile;

    //debug:
    private float cd = 1;
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
                Shoot();
                cdCounter = cd;
            }
            else
            {
                cdCounter -= Time.deltaTime;
            }
        }
	}

    void Shoot()
    {
        Projectile projectile = Instantiate(_projectile, transform.position, Quaternion.EulerAngles(90,0,0)).GetComponent<Projectile>();
        projectile.Shoot(_player, _damage);
    }

}
