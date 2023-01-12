using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
  public int health = 10;

  public virtual void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0)
    {
      Dead();
    }
    // else
    // {
    //   Debug.Log("KNOCKBACK");
    //   Vector2 knockbackDirection = new Vector2(1, 0);
    //   float knockbackForce = 100f;
    //   GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce);
    // }
  }

  public virtual void Dead()
  {
    Destroy(gameObject);
  }
}
