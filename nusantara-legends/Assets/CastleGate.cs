using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleGate : Collideable
{

    public Player player;
    public GameObject openHint;
    public GameObject warning;

    protected override void onCollide(Collider2D coll)
    {
        base.onCollide(coll);
        if(coll.name == "Player")
        {
          openHint.SetActive(true);
            if (Input.GetKeyDown(KeyCode.O))
            {
                if(player.waterCount == 3)
                {
                    SceneManager.LoadScene(2);   
                }else
                {
                    warning.SetActive(true);
                }
            }
        }
    }

    protected override void notCollide()
    {
        base.notCollide();
        openHint.SetActive(false);
        warning.SetActive(false);
    }

}
