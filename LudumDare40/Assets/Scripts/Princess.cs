using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Princess : MonoBehaviour {
    public GameObject _princessSprite;
    [SerializeField] private Image winFade;
    [SerializeField] private GameObject winText;

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
            StartCoroutine(WinScreen());

            GetComponent<Collider>().enabled = false;
        }
    }

    public IEnumerator WinScreen()
    {
        winFade.gameObject.SetActive(true);
        while (winFade.color.a < 0.99)
        {
            winFade.color = Color.Lerp(winFade.color, Color.white, 1f * Time.deltaTime);
            yield return null;
        }
        winText.GetComponentInChildren<Text>().text = WinMessage();
        winText.SetActive(true);
    }

    public string WinMessage()
    {
        if (_princessSprite.activeInHierarchy)
        {
            return "Thou art in luck, this castle enwheels a princess!";
        }
        else
        {
            return "Th're is nay signeth of the princess, sadly the lady wilt has't did flee already.";
        }
    }
}
