using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public GameObject player;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<AbstractAI>() != null)
        {
            other.GetComponent<AbstractAI>().OnHit(playerStats._damage);
        }
    }

}
