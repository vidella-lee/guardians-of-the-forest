using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float currentMoveSpeed;
    //public float diagonalMoveModifier;

    private Animator anim;

    private Rigidbody2D myRigidbody;

    private bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    public bool canMove;

    private SFXManager sfxMan;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            //checks to see if the game object already exists
            playerExists = true;
            //stops Game Object from being destroyed when it changes scenes
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            //if the game object exists already, destroy the new one created when the scene loads
            Destroy(gameObject);
        }

        canMove = true;

        //make character start out facing down
        lastMove = new Vector2(0, -1f);
  
    }

    // Update is called once per frame
    void Update()
    {
       playerMoving = false;

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if (!attacking)
        {

            //When the player is moving left, the x axis will be -1 & when the player is moving right, the x axis will be 1, so this method will only be applied when the Player is moving left or right.**/
            /* if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
             {
                 //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                 myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
                 playerMoving = true;
                 lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
             }
             //When the player is moving down, the y axis will be -1 & when the player is moving up, the y axis will be 1, so this method will only be applied when the Player is moving up or down.
             if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
             {
                 //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                 myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                 playerMoving = true;
                 lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
             }

             if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
             {
                 myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
             }

             if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
             {
                 myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
             }
             */
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            //if the player is moving, (if there is input for movement)
            if(moveInput != Vector2.zero)
            {
                myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            } else
            {
                myRigidbody.velocity = Vector2.zero;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);

                sfxMan.playerAttack.Play();
            }
            //check to see if movement is happening on both horizontal and vertical axes, AKA, diagonally
            /*if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            } else
            {
                currentMoveSpeed = moveSpeed;
            } */
        }

        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);        
    }
}
