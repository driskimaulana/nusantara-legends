using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : Collideable
{
    public Player player;

    protected override void onCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
        }
    }
}
