using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject spawnParticle;
    public AudioClip pickup;

    private void OnEnable()
    {
        Instantiate(spawnParticle, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if (playerStats)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(pickup);
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
            Invoke("Destroy", 0.5f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}