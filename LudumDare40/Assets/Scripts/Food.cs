using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if (playerStats)
        {
            playerStats.AddBuff(PlayerStats.Buff.Dysentery);
            Destroy(gameObject);
        }
    }

}
