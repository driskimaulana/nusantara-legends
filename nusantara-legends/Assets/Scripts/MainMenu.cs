using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource clicksound;
    public GameObject credits;
    public GameObject creditsChar;
    public GameObject missionListUI;
    public GameObject choosenMission;
    public GameObject buttonMenu;

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

    public void MissionList()
    {
        clicksound.Play();
        buttonMenu.SetActive(false);
        missionListUI.SetActive(true);
    }

    public void ChooseMission()
    {
        clicksound.Play();
        choosenMission.SetActive(true);
    }

    public void BackMainMenu()
    {
        clicksound.Play();
        missionListUI.SetActive(false);
        buttonMenu.SetActive(true);
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
