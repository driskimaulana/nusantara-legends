using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public float moveSpeed = 1f;
  public float collisionOffset = 0.05f;
  public ContactFilter2D movementFilter;
  public SwordAttack swordAttack;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

  Rigidbody2D rb;
  Vector2 movementInput;
  Animator animator;
  SpriteRenderer spriteRenderer;
  List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

  bool canMove = true;

    private BoxCollider2D boxCollider;
    private Vector3 deltaMove;

    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
    healthBar.SetHealth(currentHealth);

        boxCollider = GetComponent<BoxCollider2D>();
    }

  // Update is called once per frame
  void Update()
  {

        // get input arrow or awsd
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        deltaMove = new Vector3(x, y, 0);

        Debug.Log(x);

        if(x < 0)
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

        


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
  }

    private void TakeDamage()
    {
        currentHealth -= 10;
        healthBar.SetHealth(currentHealth);
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
