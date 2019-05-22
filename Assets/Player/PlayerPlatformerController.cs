using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {


    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public int currentStance = 1;
    public bool canDoubleJump = true;
    public float specAbilityTimer = 0f;
    public float dashPower = 10f;
    public bool UsingPower = false;
    //1 for speed, 2 for power and 3 for defense(from speed) and 4 for defense(from power) 
    //(controls: press z for speed, press x for power and hold c for defense)
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame


    void SetStance()
    {
        //Check input for change in stance
        //If player wants to switch to speed stance and is not already in speed stance
        if (Input.GetKeyDown(KeyCode.Z) && currentStance != 1)
        {
            //Set current stance to speed
            currentStance = 1;
            gravityMod = 1f;
        }
        else if(Input.GetKeyDown(KeyCode.X) && currentStance != 2)  //Power Stance
        {
            //Set current stance to power
            currentStance = 2;
            gravityMod = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.C) && currentStance != 3)  //Defense Stance
        {
            gravityMod = 10f;
            //Set current stance to defense
            if (currentStance == 1)
            {
                currentStance = 3; //Going into defense stance from speed
            }
            else
            {
                currentStance = 4; //Going into defense stance from power
            }
        }
        else if (Input.GetKeyUp(KeyCode.C) && ((currentStance == 3) || (currentStance == 4)))  //Defense Stance released
        {
            gravityMod = 1f;
            //Set current stance to previous stance
            if (currentStance == 3)
            {
                currentStance = 1; //Going into speed stance from defense
            }
            else
            {
                currentStance = 2; //Going into power stance from defense
            }
        }

    }
    

    protected override void ComputeVelocity()
    {
        SetStance();
        specAbilityTimer += Time.deltaTime;    //Add to timer
        Vector2 move = Vector2.zero;
        if (currentStance == 1)
        {
            if(specAbilityTimer > 0.1f)
            {
                UsingPower = false;
                dashPower = 1.0f;
            }
            move.x = Input.GetAxis("Horizontal") * 1.2f * dashPower;    //Speed mulitplier while in speed stance
        }
        else if(currentStance == 2)
        {
            move.x = Input.GetAxis("Horizontal");   //Regular speed while in power stance
        }

        //Jump while grounded. Change to implement double jump
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if ((grounded) || (colliding) || (currentStance == 1 && canDoubleJump))
            {
                if((!grounded)||(!colliding))
                {
                    //Player is double jumping
                    canDoubleJump = false;
                }
                else
                {
                    //Player is regular jumping
                    //Set canDoubleJump to true if current stance is speed
                    if(currentStance == 1)
                    {
                        canDoubleJump = true;
                    }
                }

                if (currentStance == 1)
                {
                    velocity.y = jumpTakeOffSpeed * 1.2f;
                }
                else if (currentStance == 2)
                {
                    velocity.y = jumpTakeOffSpeed;
                }

            }
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            if(velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        targetVelocity = move * maxSpeed;
      

        if(Input.GetButtonDown("Jump"))
        {
            //Shoot for power, dash for speed
            if(currentStance == 1)
            {
                //Dash
                if(specAbilityTimer > 1.0f)
                {
                    //If dash hasn't been used for 1 second1 enable it's use again
                    UsingPower = true;
                    dashPower = 5f;
                    specAbilityTimer = 0.0f;
                }
            }
            else if(currentStance == 2)
            {
                //Shoot
                UsingPower = true;
                //Shooting code goes here
                //Use the same timer as the dash ability but change the 
                //Need direction and bullet class
                specAbilityTimer = 0.0f;
            }
        }
    }

}
