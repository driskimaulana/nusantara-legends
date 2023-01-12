using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Collideable
{
  public Collider2D swordCollider;
  public float damage = 3;
  public float pushForce = 2.0f;

  Vector2 rightAttackOffset;

  protected override void Start()
  {
    base.Start();
    rightAttackOffset = transform.position;
  }

  protected override void Update()
  {
    base.Update();
  }

  protected override void onCollide(Collider2D coll)
  {
    if (coll.tag == "Enemy")
    {
      // Debug.Log(coll.name);
    }
  }

  public void StartAttack()
  {
    swordCollider.enabled = true;
  }

  public void StopAttack()
  {
    swordCollider.enabled = false;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("ONHIT");
    if (other.CompareTag("Enemy"))
    {
      other.SendMessage("TakeDamage", damage);
    }
  }
}
