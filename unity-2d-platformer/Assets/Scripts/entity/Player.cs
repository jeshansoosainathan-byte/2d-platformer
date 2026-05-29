using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    // References to components
    public Rigidbody2D body;
    public Animator animator;

    // Player movement parameters
    public float speed = 5f;
    public float jumpStrength = 10f;
    public float maxJumpTime = 0.30f;

    private bool isJumping = false;
    public float maxCoyoteTime = 0.100f; //seconds

    private float coyoteTimeRemaining;
    private float jumpTimeRemaining;

    public float gravityScale = -10;

    public UIManager manager;




    public SpriteRenderer spriteRenderer;

    public LayerMask groundLayer;

    public CapsuleCollider2D capsuleCollider;
 


    //Physics / raycast Handling

    Vector2 edgeClipTopOrigin;
    Vector2 edgeClipBotOrigin;
    Vector2 edgeClipDirection;


    public float raycastDistance = 0.05f;

    public bool hasExitKey = false;

    public int platformKeys = 0;

    public float groundDistance = 2;

    public int score = 0;



 

    void Awake()
    {



    }


    








    void Update()
    {

        float moveX = move.action.ReadValue<Vector2>().x;

        

        //Jump Button
        bool jump = Input.GetButtonDown("Jump");


        if (moveX != 0)
        {
            float force = moveX * speed;



            bool isFacingLeft = moveX < 0;

            spriteRenderer.flipX = isFacingLeft;


            Vector2 centre = transform.position;
            Vector2 extents = capsuleCollider.bounds.extents;
            float extentsX = isFacingLeft ? -extents.x : extents.x;



            edgeClipTopOrigin = centre + new Vector2(extentsX, extents.y);
            edgeClipBotOrigin = centre + new Vector2(extentsX, -extents.y);


            Vector2 direction = Vector2.Normalize(new Vector2(extentsX, 0));
            edgeClipDirection = new Vector2(extentsX, 0);
            Vector2 edgeClipRayDistance = direction * raycastDistance;
            bool hitTop = Physics2D.Raycast(edgeClipTopOrigin, direction, raycastDistance, groundLayer);
            bool hitBot = Physics2D.Raycast(edgeClipBotOrigin, direction, raycastDistance, groundLayer);

            if (!hitTop && !hitBot)
            {
                body.linearVelocityX = force;

            }
            Debug.DrawLine(edgeClipTopOrigin, edgeClipTopOrigin + edgeClipRayDistance, hitTop ? Color.red : Color.white);
            Debug.DrawLine(edgeClipBotOrigin, edgeClipBotOrigin + edgeClipRayDistance, hitBot ? Color.red : Color.white);


            animator.SetFloat("movespeedx", Mathf.Abs(moveX));


           

        }


        //JUMP
        Vector2 Origin = this.transform.position;
        Vector2 rayDirection = Vector2.down;
        
        bool isGrounded = Physics2D.Raycast(Origin, rayDirection, groundDistance, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        coyoteTimeRemaining -= Time.deltaTime;

        if (isGrounded)
        {

            //Reset coyote time timer because we are grounded



            coyoteTimeRemaining = maxCoyoteTime;




        }

        if (isGrounded || coyoteTimeRemaining > 0)
        {
            if (jump)
            {

                coyoteTimeRemaining = 0;
                isJumping = true;
                jumpTimeRemaining = maxJumpTime;

            }
        }



        //if we can continue holding down jump

        if (jumpTimeRemaining > 0)
        {

            if (jump)
            {
                body.linearVelocityY = jumpStrength;

            }
            else
            {
                isJumping = false;
                jumpTimeRemaining = 0;
            }

            jumpTimeRemaining -= Time.deltaTime;

        }

        if (body.linearVelocityY < 0)
        {
            body.AddForceY(gravityScale);



        }

    }

    private void OnValidate()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        if (capsuleCollider == null)
        {



            capsuleCollider = GetComponent<CapsuleCollider2D>();
        }

    }

    private void Reset()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        if (capsuleCollider==null)
        {



                capsuleCollider = GetComponent<CapsuleCollider2D>();
        }
    }

    public void UpdateUI()
    {

        manager.UpdateUI();


    }



}
