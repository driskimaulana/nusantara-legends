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

  Rigidbody2D rb;
  Vector2 movementInput;
  Animator animator;
  SpriteRenderer spriteRenderer;
  List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

  bool canMove = true;

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (canMove)
    {
      if (movementInput != Vector2.zero)
      {
        bool success = TryMove(movementInput);

        if (!success)
          success = TryMove(new Vector2(movementInput.x, 0));
        if (!success)
          success = TryMove(new Vector2(0, movementInput.y));

        // set animation moving
        animator.SetBool("isMove", success);
      }
      else
        animator.SetBool("isMove", false);

      // set flip character left and right
      if (movementInput.x < 0)
        spriteRenderer.flipX = true;
      else if (movementInput.x > 0)
        spriteRenderer.flipX = false;
    }
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
