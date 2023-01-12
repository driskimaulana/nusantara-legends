using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Damageable
{
  public float moveSpeed = 1f;
  public float collisionOffset = 0.05f;
  public ContactFilter2D movementFilter;
  public SwordAttack swordAttack;


  public int maxHealth = 100;
  public int currentHealth;
    public int lives = 3;

  public HealthBar healthBar;

  public int waterCount;

  public TMPro.TextMeshProUGUI mission;

    public GameObject hearth1;
    public GameObject hearth2;
    public GameObject hearth3;

    public GameObject gameOverUI;

    public AudioSource gameOverSound;
    public AudioSource backgroundMusic;

  Rigidbody2D rb;
  Vector2 movementInput;
  Animator animator;
  SpriteRenderer spriteRenderer;
  List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

  bool canMove = true;

  private BoxCollider2D boxCollider;
  private Vector3 deltaMove;

  private RaycastHit2D hit;

    public AudioSource swingSound;

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
    healthBar.SetHealth(currentHealth);
    spriteRenderer.flipX = true;

    boxCollider = GetComponent<BoxCollider2D>();

    waterCount = 0;
  }

  // Update is called once per frame
  void Update()
  {
    if (canMove)
    {
      // get input arrow or awsd
      float x = Input.GetAxisRaw("Horizontal");
      float y = Input.GetAxisRaw("Vertical");

      deltaMove = new Vector3(x, y, 0);

            if (waterCount != 3)
            {
                mission.text = "Kumpulkan air dari tiga anak sungai (" + waterCount.ToString() + "/3)";
            }
            else
            {
                mission.text = "Kumpulkan air dari tiga anak sungai (" + waterCount.ToString() + "/3). Silakan menuju hulu sungai.";
            }

      if (x < 0)
      {
        spriteRenderer.flipX = true;
      }

      // set the player direction
      if (deltaMove.x < 0)
      {
        transform.localScale = new Vector3(1, 1, 1);
      }
      else if (deltaMove.x > 0)
      {
        transform.localScale = new Vector3(-1, 1, 1);
      }

      hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, deltaMove.y), Mathf.Abs(deltaMove.y * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));

      if (hit.collider == null)
      {
        // move the player
        transform.Translate(0, deltaMove.y * Time.deltaTime, 0);
      }

      hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(deltaMove.x, 0), Mathf.Abs(deltaMove.x * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));

      bool success = TryMove(movementInput);

      if (hit.collider == null)
      {
        // set animation moving
        animator.SetBool("isMove", success);
        // move the players
        transform.Translate(deltaMove.x * Time.deltaTime, 0, 0);
      }


    }
  }

    public void GetDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if(health <= 0)
        {
            lives--;
            if(lives == 0)
            {
                gameOverSound.Play();
                backgroundMusic.Pause();
                hearth1.SetActive(false);
                gameOverUI.SetActive(true);
                Time.timeScale = 0f;
            }else if(lives == 2)
            {
                health = maxHealth;
                healthBar.SetHealth(health);
                hearth3.SetActive(false);
            }else if(lives == 1)
            {
                health = maxHealth;
                healthBar.SetHealth(health);
                hearth2.SetActive(false);
            }
        }
    } 

  public override void TakeDamage(int damage)
  {
    base.TakeDamage(damage);
    healthBar.SetHealth(currentHealth);
  }

  public override void Dead()
  {
  }

  private bool TryMove(Vector2 direction)
  {
    if (direction != Vector2.zero)
    {
      int count = rb.Cast(
          movementInput,
          movementFilter,
          castCollisions,
          moveSpeed * Time.fixedDeltaTime + collisionOffset
        );

      if (count == 0)
      {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        return true;
      }
      else return false;
    }
    else return false;
  }

  void OnMove(InputValue movementValue)
  {
    movementInput = movementValue.Get<Vector2>();
  }

  void OnFire()
  {
    animator.SetTrigger("swordAttack");
  }

  public void SwordAttack()
  {
        swingSound.Play();
    LockMovement();
    swordAttack.StartAttack();
  }

  public void EndSwordAttack()
  {
    UnlockMovement();
    swordAttack.StopAttack();
  }

  public void LockMovement()
  {
    canMove = false;
  }

  public void UnlockMovement()
  {
    canMove = true;
  }
}
