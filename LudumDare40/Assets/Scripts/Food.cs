﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if (playerStats)
        {
            int val = Random.Range(0, 100);
            if (val < 33)
                playerStats.AddBuff(PlayerStats.Buff.Dysentery);
            else if(val < 66)
            {
                playerStats.AddBuff(PlayerStats.Buff.Weakness);
            }
            else
            {
                playerStats.Heal(20);
            }
            Destroy(gameObject);
        }
    }
}