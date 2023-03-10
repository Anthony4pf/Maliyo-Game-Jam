using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    private float faceDirectionX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum movementState { idle, running, jump, falling }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        faceDirectionX = SimpleInput.GetAxis("Horizontal");
        HandleMovement();
        updateAnimState();
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            AudioManager.instance.Play("Jump");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }

    }

    private void HandleMovement()
    {
        rb.velocity = new Vector2(faceDirectionX * moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded())
        {
            AudioManager.instance.Play("Jump");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }

    private void updateAnimState()
    {
        movementState state;

        if (faceDirectionX > 0f)//right
        {
            state = movementState.running;
            sprite.flipX = false;
        }
        else if (faceDirectionX < 0f)//left
        {
            state = movementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = movementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);

    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
