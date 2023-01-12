using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Damageable
{
  public Transform player;
  public float chaseRange = 1.5f;
  public float moveSpeed = 0.5f;
  public float damageInterval = 1f;
  public float damage = 3f;
  private float lastDamageTime;

  private SpriteRenderer rend;
  Animator animator;
  public float attackRange = 0.3f;
  public bool canMove = true;

  void Start()
  {
    rend = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (canMove)
    {
      Debug.Log("CAN MOVE");
      float distance = Vector3.Distance(transform.position, player.position);

      if (distance < chaseRange)
      {
        if (distance <= attackRange)
        {
          animator.SetTrigger("isAttack");
        }
        else
        {
          animator.SetBool("run", true);
          if (player.position.x > transform.position.x)
          {
            rend.flipX = false;
          }
          else if (player.position.x < transform.position.x)
          {
            rend.flipX = true;
          }
          transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

          // if (transform.position == player.position && Time.time - lastDamageTime > damageInterval)
          // {
          //   player.SendMessage("TakeDamage", damage);
          //   lastDamageTime = Time.time;
          // }
        }
      }
      else
      {
        animator.SetBool("run", false);
        canMove = true;
      }
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    // Debug.Log("OnCollisionEnter2D is called 2");
  }

  // private void OnTriggerStay2D(Collider2D collision)
  // {
  //   // Debug.Log("STAY");
  //   // if (collision.CompareTag("Player"))
  //   // {
  //   //     Debug.Log("PLAYER ATTACKED");
  //   //     lastDamageTime = Time.time;
  //   // }
  // }

  public override void TakeDamage(int damage)
  {
    Debug.Log("ENEMY ATTACKKKKKKK");
    base.TakeDamage(Mathf.RoundToInt(damage));
    animator.SetTrigger("attacked");
  }

  public void enemyIsAttacking()
  {
    canMove = false;
  }

  public void enemyIsStopAttacking()
  {
    canMove = true;
  }

}
