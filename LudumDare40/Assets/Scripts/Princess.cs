using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour {
    public GameObject _princessSprite;

	// Use this for initialization
	void Start () {
		if(Random.Range(0, 100) < 40)
        {
            _princessSprite.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStats>())
        {
            if (_princessSprite.activeInHierarchy)
            {
                Debug.Log("Thou art in luck, this castle enwheels a princess!");
            }
            else
            {
                Debug.Log("Th're is nay signeth of the princess, sadly the lady wilt has't did flee already.");
            }

            GetComponent<Collider>().enabled = false;
        }
    }
}
