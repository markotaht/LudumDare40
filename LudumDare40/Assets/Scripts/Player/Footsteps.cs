using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    public List<AudioClip> footsteps = new List<AudioClip>();
    private AudioClip stepsound;
    AudioSource playerSound;

    // Use this for initialization
    void Start () {
        playerSound = transform.GetComponent<AudioSource>();
	}
	
    void Step(){
        int index = Random.Range(0, 3);
        stepsound = footsteps[index];
        playerSound.clip = stepsound;
        playerSound.pitch = Random.Range(0.75f, 1.0f);
        playerSound.PlayOneShot(stepsound, Random.Range(0.75f, 1.0f));
    }
}
