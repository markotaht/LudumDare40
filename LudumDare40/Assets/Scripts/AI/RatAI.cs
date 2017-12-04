using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : AbstractAI {

	// Use this for initialization
	void Start () {
        cd = 3;
        cdCounter = 0;
    }
	
    public override void Attack()
    {
        _player.GetComponent<PlayerStats>().OnHit(_damage,"Rat");
        if(Random.Range(0, 100) < 25)
        {
            _player.GetComponent<PlayerStats>().AddBuff(PlayerStats.Buff.Weakness);
        } else
        {
            _player.GetComponent<PlayerStats>().AddBuff(PlayerStats.Buff.Bleeding);
        }
    }

}
