using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if (playerStats)
        {
            if (Random.Range(0, 100) < 50)
                playerStats.AddBuff(PlayerStats.Buff.Dysentery);
            playerStats.AddBuff(PlayerStats.Buff.Weakness);
        }
        else
        {
            playerStats.Heal(20);
            Destroy(gameObject);
        }
    }
}