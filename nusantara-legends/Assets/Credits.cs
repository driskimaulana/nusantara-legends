using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject creditsChar;
    public GameObject creditsSound;
    public GameObject credits;

    public AudioSource clickEffect;

    public void Next()
    {
        clickEffect.Play();
        creditsChar.SetActive(false);
        creditsSound.SetActive(true);
    }

    public void Close()
    {
        clickEffect.Play();
        creditsChar.SetActive(false);
        creditsSound.SetActive(false);
        credits.SetActive(false);
    }
}
