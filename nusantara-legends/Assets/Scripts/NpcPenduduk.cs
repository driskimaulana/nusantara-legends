using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcPenduduk : Collideable
{
    public Dialogue dialogue;

    public GameObject hintText;

    protected override void onCollide(Collider2D coll)
    {
        hintText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.T) && coll.name == "Player")
        {
            hintText.SetActive(false);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, true);
        }
        
    }

    protected override void notCollide()
    {
        base.notCollide();

        hintText.SetActive(false);
    }
}
