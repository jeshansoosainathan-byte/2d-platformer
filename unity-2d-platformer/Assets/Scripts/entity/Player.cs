//Jeshan Soosainathan - 000924893
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{

    // References to components
    public Rigidbody2D body;
    public Animator animator;

    [Header("Player Move Parameters")]
    public float default_speed = 5f;
    public float powerup_speed = 7.5f;
    public float jumpStrength = 10f;
    public float maxJumpTime = 0.30f;
    public float climb_speed = 1.0f;
    public float fallScale = -10;
    public float defaultGravity = 1;
    public float move_speed = 5f;
    private bool isJumping = false;
    public float maxCoyoteTime = 0.100f; //seconds

    private float coyoteTimeRemaining;
    private float jumpTimeRemaining;



    public UIManager manager;




    public SpriteRenderer spriteRenderer;

    public LayerMask groundLayer;

    public CapsuleCollider2D capsuleCollider;

    public bool isDead = false;

    //Physics / raycast Handling

    Vector2 edgeClipTopOrigin;
    Vector2 edgeClipBotOrigin;
    Vector2 edgeClipDirection;


    public float raycastDistance = 0.05f;

    public bool hasExitKey = false;

    public int platformKeys = 0;

    public float groundDistance = 2;

    public int score = 0;


    private float horizontal = 0;

    private int deathTimer = 0;

    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction InteractAction;
    


    public bool isInteracting = false;

    public bool isClimbing = false;


    private int powerupTimer = 0;

    public bool onClimeable = false;

    [Header("Sprites")]
    public Sprite climbSprite;
    public Sprite deadSprite;


    public GameObject deathScreen;


      

    public void powerUp()
    {

        powerupTimer = 5000;
        move_speed = powerup_speed;

    }

    //Checks if interacting, makes sure player is on a climeable while climbing
    public void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (isInteracting)
        {

          
            IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();

            if (interactable != null)
            {
              
                interactable.interact(this.gameObject);

            } 


        }

        if (isClimbing)
        {

            IClimable climable = collision.gameObject.GetComponent<IClimable>();

            if (climable != null)
            {

                onClimeable = true;

            }

        }


    }





    //Checks for input per frame
    private void Update()
    {
        isInteracting = InteractAction.IsPressed();
        isJumping = jumpAction.IsPressed();


      


    }


    //Turns off climeable on exiting climeable object
    public void OnTriggerExit2D(Collider2D collision)
    {
        IClimable climable = collision.gameObject.GetComponent<IClimable>();

        if (climable != null)
        {

            
            StopClimbing();

        }


    }

    //Climbing, Ground and Jump movement
    void FixedUpdate()
    {
        float vertical = moveAction.ReadValue<Vector2>().y;


        if (vertical != 0)
        {
           
            if (onClimeable)
            {
                isClimbing = true;


            }

        }



        if (isDead)
        {
            deathTimer++;


            deathScreen.SetActive(true);
             if (deathTimer >= 100)
            {
           
                SceneManager.LoadScene("PlayAgain");


            }

            return;


        }


        if (powerupTimer > 0)
        {

            powerupTimer--;

            if (powerupTimer == 0)
            {

                move_speed = default_speed;


            }


        }

        horizontal = moveAction.ReadValue<Vector2>().x;

        animator.SetFloat("move_speed", Mathf.Abs(horizontal));



        //Climbing Code
        if (isClimbing)
        {




            if (!onClimeable)
            {

                StopClimbing();
            }
            else
            {
                body.constraints |= RigidbodyConstraints2D.FreezePositionX;

               

                body.gravityScale = 0;
                float force = vertical * climb_speed;

                body.linearVelocityY = force;

               

                if (force == 0)
                {
                    animator.speed = 0;
                    spriteRenderer.sprite = climbSprite;
                } else
                {
                    animator.SetBool("isClimbing", true);
                    animator.speed = 1;
                }

            }

        }


        if (horizontal != 0)
        {
 
            



            float force = horizontal * move_speed;
            bool isFacingLeft = horizontal < 0;
            
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
            if (isJumping)
            {

                coyoteTimeRemaining = 0;

                jumpTimeRemaining = maxJumpTime;

            }
        }



        //if we can continue holding down jump

        if (jumpTimeRemaining > 0)
        {

            if (isJumping && !isClimbing)
            {
                body.linearVelocityY = jumpStrength;

            }
            else
            {

                jumpTimeRemaining = 0;
            }

            jumpTimeRemaining -= Time.deltaTime;

        }

        if (body.linearVelocityY < 0)
        {
            body.AddForceY(fallScale);


 
        }


        animator.SetFloat("velocityY", body.linearVelocityY);







    }

    public void StopClimbing()
    {
        onClimeable = false;
        isClimbing = false;
        body.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        body.gravityScale = defaultGravity;
        animator.speed = 1;

        animator.SetBool("isClimbing", false);

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
        if (capsuleCollider == null)
        {



            capsuleCollider = GetComponent<CapsuleCollider2D>();
        }
    }

    public void UpdateUI()
    {

        manager.UpdateUI();


    }
    public void OnEnable()
    {
        
        moveAction = InputSystem.actions.FindAction("Move");
        InteractAction = InputSystem.actions.FindAction("Interact");
        jumpAction = InputSystem.actions.FindAction("Jump");
        

    }

    internal void kill()
    {

  

        isDead = true;

        animator.SetBool("isDead", true);

        spriteRenderer.sprite = deadSprite;
    }

 
}
