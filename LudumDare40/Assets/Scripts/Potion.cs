using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    public GameObject spawnParticle;
    public AudioClip pickup;

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
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(pickup);
            if (Random.Range(0, 100) < 60)
            {
                playerStats.RemoveRandomBuff();
            }
            else
            {
                playerStats.AddRandomBuff();
            }
            Invoke("Destroy", 0.5f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
