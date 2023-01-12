using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collideable : MonoBehaviour
{
  public ContactFilter2D filter;
  private BoxCollider2D boxCollider;
  private Collider2D[] hits = new Collider2D[10];


  protected virtual void Start()
  {
    boxCollider = GetComponent<BoxCollider2D>();
  }

  protected virtual void Update()
  {
    // collision work
    boxCollider.OverlapCollider(filter, hits);

    for (int i = 0; i < 2; i++)
    {
      if (hits[i] == null)
      {
        notCollide();
        // continue;
      }
      else
      {
        onCollide(hits[i]);
      }


      // back hits to null
      hits[i] = null;
    }
  }

  protected virtual void onCollide(Collider2D coll)
  {
  }

  protected virtual void notCollide()
  {

  }

}
