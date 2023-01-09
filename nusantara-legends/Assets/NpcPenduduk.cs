using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPenduduk : Collideable
{
    public Dialogue dialogue;

    public GameObject hintText;

    public static bool isMeet = false;

    protected override void onCollide(Collider2D coll)
    {
        isMeet = true;

        hintText.SetActive(true);

        if (isMeet && Input.GetKeyDown(KeyCode.T))
        {
            hintText.SetActive(false);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, true);
        }
        
    }

    protected override void notCollide()
    {
        base.notCollide();

        if(isMeet == true) hintText.SetActive(false);
    }
}
