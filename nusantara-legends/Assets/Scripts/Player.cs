using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 deltaMove;

    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // get input arrow or awsd
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        deltaMove = new Vector3(x, y, 0);

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

        if (hit.collider == null)
        {
            // move the players
            transform.Translate(deltaMove.x * Time.deltaTime, 0, 0);
        }
        
        
    }
}
