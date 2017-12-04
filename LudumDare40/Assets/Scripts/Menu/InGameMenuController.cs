using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuController : MonoBehaviour {

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject debuff;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject panel;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            debuff.SetActive(!debuff.activeInHierarchy);
            health.SetActive(!health.activeInHierarchy);
            panel.SetActive(!panel.activeInHierarchy);
            menuPanel.SetActive(!menuPanel.activeInHierarchy);
            if (menuPanel.activeInHierarchy)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
	}

    public void Resume()
    {
        debuff.SetActive(true);
        health.SetActive(true);
        panel.SetActive(true);
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
