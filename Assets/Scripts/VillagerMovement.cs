using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidbody;

    private bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;


        ChooseDirection();

        
        // Her fortæller scriptet npc'en hvor max og min point er for npc'ens walkzone 
        //-----------------------------------------------------------------

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        //-------------------------------------------------------------------
    }

	
	// Update is called once per frame
	void Update () {


        // Her tjekker scriptet om npc'en er inden for sin walkarea.
        // Hvis npc'en ikke er inden for walkarea så bliver npc'en bedt om at stoppe og finde en anden vej.
        //----------------------------------------------------------------------------------------------

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;


            switch (walkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);

                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }

                    break;

                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);

                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }



                    break;

                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);

                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }


                    break;

                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);

                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }

                    break;

            }
            //----------------------------------------------------------------------------------------------


            // Her for npc'en at vide om den har lov til at bevæge sig eller om den skal stå stille 
            // ------------------------------------------------------------------------------------

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if (waitCounter< 0)
            {
                ChooseDirection();
            }
        }
	}
    //----------------------------------------------------------------------------------------------

    // Her for npc'en at vide at den skal tage en random retning når den skal bevæge sig
    //----------------------------------------------------------------------------------------------


    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
    //----------------------------------------------------------------------------------------------

}
