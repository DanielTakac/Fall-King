using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public PhysicsMaterial2D bounceMat, normalMat;

    public LayerMask groundMask;

    public GameObject jumpEffect;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject middleLeg;

    private Rigidbody2D rb;

    public float walkSpeed;
    private float moveInput;
    public float jumpValue = 0.0f;
    public float jumpChargingSpeed = 0.1f;

    private Vector3 leftLegPosition;
    private Vector3 rightLegPosition;
    private Vector3 middleLegPosition;

    public bool isGrounded;
    public bool canJump = true;

    void Start(){

        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    void Update(){

        leftLegPosition = leftLeg.transform.position;
        rightLegPosition = rightLeg.transform.position;
        middleLegPosition = middleLeg.transform.position;

        if (Input.GetKeyUp("space")){

            canJump = true;

        }

        moveInput = Input.GetAxisRaw("Horizontal");

        if (jumpValue == 0.0f && isGrounded){

            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);

        }

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
        new Vector2(0.9f, 0.4f), 0f, groundMask);

        if(jumpValue > 0){

            rb.sharedMaterial = bounceMat;

        }
        else
        {

            rb.sharedMaterial = normalMat;

        }

        if (Input.GetKey("space") && isGrounded && canJump){

            jumpValue += jumpChargingSpeed * Time.deltaTime;

        }

        if(Input.GetKeyDown("space") && isGrounded && canJump){

            rb.velocity = new Vector2(0.0f, rb.velocity.y);

        }

        if(jumpValue >= 21.0f && isGrounded){

            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;

            rb.velocity = new Vector2(tempx, tempy);

            Invoke("ResetJump", 0.25f);

            if (moveInput == -1f) { Instantiate(jumpEffect, rightLegPosition, new Quaternion(0, 0, 0, 0)); }
            if (moveInput == 1f) { Instantiate(jumpEffect, leftLegPosition, new Quaternion(0, 0, 0, 0)); }
            if (moveInput == 0f) { Instantiate(jumpEffect, middleLegPosition, new Quaternion(0, 0, 0, 0)); }

        }

        if (Input.GetKeyUp("space")){

            if (isGrounded){

                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f;



                if (moveInput == -1f){ Instantiate(jumpEffect, rightLegPosition, new Quaternion(0, 0, 0, 0)); }
                if (moveInput ==  1f){ Instantiate(jumpEffect, leftLegPosition, new Quaternion(0, 0, 0, 0)); }
                if (moveInput ==  0f){ Instantiate(jumpEffect, middleLegPosition, new Quaternion(0, 0, 0, 0)); }

                }

            canJump = true;

        }

        if (!Input.GetKey("space")){

            canJump = true;

        }

    }

    void ResetJump(){

        canJump = false;
        jumpValue = 0;

    }

}
