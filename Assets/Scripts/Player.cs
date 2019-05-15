using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//remember how to do this dumby
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    #region Var
    //variables
    public LayerMask groundLayer;
    public float runSpeed = 8f;
    public float walkSpeed = 6f;
    public float gravity = -15f;
    //public float crouchSpeed = 4f;
    public float jumpHeight = 8f;
    public float groundRayDistance = 1.1f;
    public Vector3 moveDirec;
    public CharacterController charController;
    private bool isJumping = false;

    
    #endregion

    #region start
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }
    #endregion

    #region update
    // Update is called once per frame
    void Update()
    {
        //Vector3 setup x y axis



        #region AllInUpdateMovement
        //moveDirec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        ////base speed
        //moveDirec *= walkSpeed;
        //moveDirec = transform.TransformDirection(moveDirec);

        ////sprinting

        //if (Input.GetKeyDown("LShift"))
        //{
        //    moveDirec *= runSpeed;
        //}

        //if (charController.isGrounded)
        //{

        //    //jumping
        //    if (Input.GetButton("Jump"))
        //    {
        //        // moveDirec.y is equal to jumpHeight
        //        moveDirec.y = jumpHeight;
        //    }
        //}
        //moveDirec.y -= gravity * Time.deltaTime;
        ////we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
        //charController.Move(moveDirec * Time.deltaTime);
        #endregion



        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        //keep speed consistant, speed is not increased when moving diagonal
        Vector3 normalized = new Vector3(inputH, 0f, inputV);
        normalized.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //move = inputH, inputV
            Sprint(normalized.x, normalized.z);
        }
        else
        {
            Walk(normalized.x, normalized.z);
        }

        //jump when on ground and when button pressed
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            //jump
            Jump();

        }

        //cant jump in air
        if (!IsGrounded() && isJumping)
        {
            isJumping = false;
        }

        //grav acceleration set to 0 if jumping or grounded
        if (IsGrounded() && !isJumping)
        {

            moveDirec.y = 0f;
        }


        moveDirec.y += gravity * Time.deltaTime;
        charController.Move(moveDirec * Time.deltaTime);
    }
    #endregion
    //move player in given direction horiz/verti
    public void Move(float inputH, float inputV, float speed)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);
        // convert local direction to worldspace
        direction = transform.TransformDirection(direction);
        moveDirec.x = direction.x * speed;
        moveDirec.z = direction.z * speed;
       
    }

    //testGrounded
    private bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, -transform.up);

        //return Physics.Raycast(groundRay, groundRayDistance)

        //raycast perform
        if (Physics.Raycast(groundRay, groundRayDistance, groundLayer))
        {
            //return true if hit
            return true;
        }

        //else return false
        return false;

        //return exits the function 
    }

    public void Walk(float horizontal, float vertical)
    {
        Move(horizontal, vertical, walkSpeed);
    }

    public void Sprint(float horizontal, float vertical)
    {
        Move(horizontal, vertical, runSpeed);
    }

    public void Jump()
    {
        moveDirec.y = jumpHeight;
        isJumping = true;
    }


}
