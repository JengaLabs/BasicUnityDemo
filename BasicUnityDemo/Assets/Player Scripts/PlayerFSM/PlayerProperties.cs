using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Hold onto abunch of data that fsm will need to use
public class PlayerProperties 
{

    public Rigidbody PlayerRigidbody
    {
        get { return _PlayerRigidbody; }
    }


    public PlayerProperties(Rigidbody _playerRigidbody, Transform _playerCamera, Transform _orientation)
    {

        //Set some propeties needed for the FSM

        _PlayerRigidbody = PlayerRigidbody;

        playerCam = _playerCamera;
        orientation = _orientation;

    }

    //Assingables
    public Transform playerCam;
    public Transform orientation;

    //Other
    private Rigidbody _PlayerRigidbody;

    //Rotation and look
    public float xRotation;
    public float sensitivity = 50f;
    public float sensMultiplier = 1f;

    //Movement
    public float moveSpeed = 4500;
    public float maxSpeed = 20;
    public bool grounded;
    public LayerMask whatIsGround;

    public float counterMovement = 0.175f;
    public float threshold = 0.01f;
    public float maxSlopeAngle = 35f;

    //Crouch & Slide
    public Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    public Vector3 playerScale;
    public float slideForce = 400;
    public float slideCounterMovement = 0.2f;

    //Jumping
    public bool readyToJump = true;
    private float jumpCooldown = 0.25f;
    public float jumpForce = 550f;

    //Input
    float x, y;
    bool jumping, sprinting, crouching;

    //Sliding
    private Vector3 normalVector = Vector3.up;
    private Vector3 wallNormalVector;










}
