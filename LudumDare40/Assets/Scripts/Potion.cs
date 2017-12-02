using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if (playerStats)
        {
            if(Random.Range(0, 100) < 60)
            {
                playerStats.RemoveRandomBuff();
            }
            else
            {
                playerStats.AddRandomBuff();
            }
            Destroy(gameObject);
        }
    }
}
