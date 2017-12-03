using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    public GameObject spawnParticle;

    private void OnEnable()
    {
        Instantiate(spawnParticle, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        Instantiate(spawnParticle, transform.position, Quaternion.identity);
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
