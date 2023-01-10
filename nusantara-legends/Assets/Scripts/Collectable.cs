using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collideable
{

    protected bool isCollected;

    protected override void onCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            OnCollect();
    }

    protected virtual void OnCollect()
    {
        isCollected = true;
        Debug.Log("Water 1 Collected");
    }

}
