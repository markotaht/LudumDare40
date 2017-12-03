using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAI : AbstractAI {

    public GameObject _projectile;

	// Use this for initialization
	void Start () {
        cd = 1;
        cdCounter = 0;
	}

    public override void Attack()
    {
        Projectile projectile = Instantiate(_projectile, transform.position, Quaternion.Euler(90,0,0)).GetComponent<Projectile>();
        projectile.Shoot(_player, _damage);
    }

}
