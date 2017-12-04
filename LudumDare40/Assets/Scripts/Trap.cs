using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public PlayerStats.Buff _buff;
    public Sprite activatedSpikes;
    public Sprite disabledSpikes;
    public SpriteRenderer spikeCosmetic;
    bool enabled;

	// Use this for initialization
	void Start () {
        enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enabled){
            spikeCosmetic.sprite = activatedSpikes;
        } else {
            spikeCosmetic.sprite = disabledSpikes;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if (playerStats)
        {
            enabled = true;
            playerStats.AddBuff(_buff);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if (playerStats)
        {
            enabled = false;
        }
    }
}
