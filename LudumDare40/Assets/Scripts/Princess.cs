using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Princess : MonoBehaviour {
    public GameObject _princessSprite;
    [SerializeField] private Image winFade;
    [SerializeField] private GameObject winText;
    private PlayerStats _playerStats;
    public GameObject _ufo;
    public GameObject _rat;
    private bool ratInScene = false;

	// Use this for initialization
	void Start () {
        float r = Random.Range(0, 100);
        if(r < 5)
        {
            //_rat.SetActive(true);
            Instantiate(_rat, transform);
            ratInScene = true;
            _princessSprite.SetActive(false);
        }
		else if(r < 50)
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
            _playerStats = other.GetComponent<PlayerStats>();
            StartCoroutine(WinScreen());

            GetComponent<Collider>().enabled = false;
        }
    }

    public IEnumerator WinScreen()
    {
        winFade.gameObject.SetActive(true);
        bool success;
        string message;
        WinMessage(out success, out message);
        if (message == "The princess wast abduct'd!") yield return new WaitForSeconds(2);
        winText.GetComponentInChildren<Text>().text = message;
        winText.SetActive(true);
        if (!success)
        {
            winText.GetComponentInChildren<Text>().color = Color.white;
            winFade.color = new Color(0, 0, 0, 0);
        }
        while (winFade.color.a < 0.99)
        {
            winFade.color = Color.Lerp(winFade.color, success ? Color.white : Color.black, 1f * Time.deltaTime);
            yield return null;
        }
    }

    public void WinMessage(out bool success, out string message)
    {
        if (_princessSprite.activeInHierarchy)
        {
            if(Random.Range(0, 100) < 10)
            {
                //UFO
                Instantiate(_ufo, transform.position, transform.rotation);
                message = "The princess wast abduct'd!";
                success = false;
                return;
            }
            if (_playerStats.HasDysentery())
            {
                message = "The princess rejects thee because thee has't shat thyself.";
                success = false;
            }
            else
            {
                message = "Thou art in luck, h'r highness likes thee!";
                success = true;
            }

        }
        else
        {
            success = false;
            if (ratInScene)
            {
                message = "A wild rat princess hath appeareth!";
                return;
            }
            float random = Random.Range(0, 100);
            if(random < 50) 
                message = "Th're is nay signeth of the princess.";
            else
                message = "Thy princess is in anoth'r castle.";
        }
    }
}
