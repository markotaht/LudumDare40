using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

    public List<AudioClip> footsteps = new List<AudioClip>();
    public List<AudioClip> attack = new List<AudioClip>();
    public AudioSource playerSound;
    AudioClip stepsound;
    AudioClip swingsound;
	
    void Step(){
        Debug.Log("Stepped (sound)");
        int index = Random.Range(0, 3);
        stepsound = footsteps[index];
        playerSound.GetComponent<AudioSource>();
        playerSound.clip = stepsound;
        playerSound.PlayOneShot(swingsound, RNG());
    }

    void Swing() {
        Debug.Log("Swing Sound");
        int index = Random.Range(0, 2);
        swingsound = attack[index];
        playerSound.GetComponent<AudioSource>();
        playerSound.clip = swingsound;
        playerSound.PlayOneShot(swingsound, RNG());
    }

    float RNG(){
        return Random.Range(0.75f, 1.0f);
    }
}
