using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D myRigidBody;

    public bool isWalking;

    public float walktime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public Collider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkZone;

    public bool canMove;
    private DialogueManager theDM;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogueManager>();

        waitCounter = waitTime;
        walkCounter = walktime;

        ChooseDirection();
        if(walkZone != null)
        {
            //value of bottom left corner of Collider
            minWalkPoint = walkZone.bounds.min;
            //value of top right corner of Collider
            maxWalkPoint = walkZone.bounds.max;

            hasWalkZone = true;
        }
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!theDM.dialogueActive)
        {
            canMove = true;
        }

        if (!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return; //return cancels out of return loop so none of the following code can run
        }

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    //move up
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    //move right
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    //move down
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 4:
                    //move left
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }
            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        } else
        {
            waitCounter -= Time.deltaTime;

            myRigidBody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        //because we are using int (and not float), Random.Range will not pick the top number so this will only return 0, 1, 2, or 3
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walktime;
    }
}
