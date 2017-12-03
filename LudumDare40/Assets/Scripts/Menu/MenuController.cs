using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour {

    public GameObject tutorial;

	public void QuitGame()
    {
        Application.Quit();
    }

    public void StarGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Tutorial()
    {
        tutorial.SetActive(true);
    }

    public void QuitTutorial()
    {
        tutorial.SetActive(false);
    }
}
