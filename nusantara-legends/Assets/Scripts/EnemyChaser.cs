using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Damageable
{
  public Transform player;
    public Player playerProfile;
  public float chaseRange = 1.5f;
  public float moveSpeed = 0.5f;
  public float damageInterval = 1f;
  public float damage = 3f;
  private float lastDamageTime;

  private SpriteRenderer rend;
  Animator animator;
  public float attackRange = 0.3f;
  public bool canMove = true;

    public AudioSource misiSuksesSound;
    public AudioSource backgroundMusic;

    public GameObject endgameUI;

    private bool enemyAttack = false;

    public int maxHealth = 100;

    public HealthBar healthBar;

    void Start()
  {
    rend = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
  }

  void Update()
  {
    if (canMove)
    {
      float distance = Vector3.Distance(transform.position, player.position);

      if (distance < chaseRange)
      {
        if (distance <= attackRange)
        {
                    enemyAttack = false;
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

    public override void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            if(this.name == "Boss")
            {
                endgameUI.SetActive(true);
                misiSuksesSound.Play();
                backgroundMusic.Pause();
                Dead();
                Time.timeScale = 0f;
            }else
            {
                misiSuksesSound.Play();
                Dead();
            }

            
        }
        // else
        // {
        //   Debug.Log("KNOCKBACK");
        //   Vector2 knockbackDirection = new Vector2(1, 0);
        //   float knockbackForce = 100f;
        //   GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce);
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
  {
        if(other.name == "Player")
        {
            playerProfile.GetDamage(5);
            Debug.Log("Player");
        }
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

  

  public void enemyIsAttacking()
  {
    canMove = false;
  }

  public void enemyIsStopAttacking()
  {
    canMove = true;
  }

}
