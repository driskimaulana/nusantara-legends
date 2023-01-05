using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
  public Collider2D swordCollider;
  public float damage = 3;

  Vector2 rightAttackOffset;

  private void Start()
  {
    rightAttackOffset = transform.position;
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
    // if (other.tag == "Enemy")
    // {
    //   IDamageable damageableObject = other.GetComponent<IDamageable>();
    //   if (damageableObject != null)
    //   {
    //     other.SendMessage("OnHit", damage);
    //   }
    //   else
    //     Debug.LogWarning("This object is not implement IDamageable");
    // }
  }
}
