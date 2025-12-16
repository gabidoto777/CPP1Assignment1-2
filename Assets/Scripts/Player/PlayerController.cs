using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]


public class controller : MonoBehaviour
{

    // Component References
    //public Transform groundCheck;
    Rigidbody2D rb;
    // References to the Collider2D component
    Collider2D col;
    // Reference to the SpriteRenderer component
    SpriteRenderer sr;
    // Reference to the GroundCheck script
    GroundCheck groundCheckScript;
    // Reference to the Animator component
    Animator anim;



    // LayerMask to identify ground objects
    // LayerMask groundLayer;

    public CoinPickUp coin;

    //Control variables
    // Movement speed of the player
    public float moveSpeed = 2f;
    // Radius for ground check
    public float groundCheckRadius = 0.02f;

    public bool isGrounded = false;

    public bool isFalling = false;

    private bool IgnoreInput = false;

    private Shoot shoot;



    // Calculate ground check position based on collider bounds
    //private Vector2 groundCheckPos => new Vector2(col.bounds.center.x, col.bounds.min.y);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
        // Get the Collider2D component attached to the player
        col = GetComponent<Collider2D>();
        // Get the SpriteRenderer component attached to the player
        sr = GetComponent<SpriteRenderer>();
        // Get the Animator component attached to the player
        anim = GetComponent<Animator>();
        // Initialize the GroundCheck script
        groundCheckScript = new GroundCheck(col, LayerMask.GetMask("Ground"), groundCheckRadius);

        shoot = GetComponent<Shoot>();


        //other option to
        //initialize ground check position using separate GameObject as a child of the player
        //GameObject newObj = new GameObject("GroundCheck");
        //newObj.transform.SetParent(transform);
        //newObj.transform.localPosition = Vector3.zero;
        // groundCheck = newObj.transform;
        //this is basically the same as creating an empty GameObject in the Unity Editor and assigning it to groundCheck, we do it here to keep everything contained in code.

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            shoot.Fire();
        }
        
        isGrounded = groundCheckScript.CheckisGrounded();

        // Update isFalling status
        isFalling = rb.linearVelocityY < 0;
        if (isFalling == true)
        {
            rb.gravityScale = 3f; //increase gravity when falling
        }

        if (isFalling && isGrounded) {
            rb.gravityScale += 1;
        }

        // Get horizontal input
        float hValue = Input.GetAxis("Horizontal");

        float vValue = Input.GetAxis("Vertical");

        // Smoothly update the player's horizontal velocity
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, new Vector2(hValue * moveSpeed, rb.linearVelocity.y), 0.1f);

        if (hValue != 0)
            sr.flipX = hValue < 0;

        // Jump when the jump button is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocityY -= 1.5f; //simulate weight increase when jumping
            rb.AddForce(Vector2.up * 12f, ForceMode2D.Impulse);
        }

        // Update animator parameters
        anim.SetFloat("hValue", Mathf.Abs(hValue));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("vValue", Mathf.Abs(vValue));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coin.coinCount++;
        }

    }

}
