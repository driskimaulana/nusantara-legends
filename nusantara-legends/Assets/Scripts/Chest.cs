using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{

    public GameObject hintText;
    public Animator openchestAnimation;
    public Player player;
    public AudioSource openChestAudio;

    protected override void onCollide(Collider2D coll)
    {
        base.onCollide(coll);

        //hintText.SetActive(true);
    }

    // protected override void notCollide()
    // {
       // base.notCollide();
        //hintText.SetActive(false);
    //}


    protected override void OnCollect()
    {
        if(!isCollected )
        {
            isCollected = true;
            openChestAudio.loop = false;
            openChestAudio.Play();
            player.waterCount++;
            openchestAnimation.enabled = true;
            Debug.Log("Water collected");
        }
    }

}