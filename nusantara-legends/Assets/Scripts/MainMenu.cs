using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource clicksound;
    public GameObject credits;
    public GameObject creditsChar;

   public void PlayGame()
    {
        clicksound.loop = false;
        clicksound.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        clicksound.loop = false;
        clicksound.Play();
        Application.Quit();
    }
    
    public void Settings()
    {
        clicksound.loop = false;
        clicksound.Play();
    }
    
    public void Credits()
    {
        clicksound.loop = false;
        clicksound.Play();
        credits.SetActive(true);
        creditsChar.SetActive(true);
    }
}
