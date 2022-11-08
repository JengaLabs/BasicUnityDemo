﻿using System;
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
        this._PlayerRigidbody = _playerRigidbody;

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

    public float counterMovement = 0.175f;
    public float threshold = 0.01f;
    public float maxSlopeAngle = 35f;


    //Jumping
    public float jumpForce = 100f;

    //Input
    float x, y;

    //Sliding
    public Vector3 normalVector = Vector3.up;
    public Vector3 wallNormalVector;


    public void Movement()
    {

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        //Extra gravity
        PlayerRigidbody.AddForce(Vector3.down * Time.deltaTime * 10);

        //Find actual velocity relative to where player is looking
        Vector2 mag = FindVelRelativeToLook();
        float xMag = mag.x, yMag = mag.y;

        //Counteract sliding and sloppy movement
        CounterMovement(x, y, mag);

        
        //Set max speed
        float maxSpeed = this.maxSpeed;


        //If speed is larger than maxspeed, cancel out the input so you don't go over max speed
        if (x > 0 && xMag > maxSpeed) x = 0;
        if (x < 0 && xMag < -maxSpeed) x = 0;
        if (y > 0 && yMag > maxSpeed) y = 0;
        if (y < 0 && yMag < -maxSpeed) y = 0;

        //Some multipliers
        float multiplier = 1f, multiplierV = 1f;

        // Movement in air 
        if (!grounded)
        {
            multiplier = 0.5f;
            multiplierV = 0.5f;
        }

        

        //Apply forces to move player
        PlayerRigidbody.AddForce(orientation.transform.forward * y * moveSpeed * Time.deltaTime * multiplier * multiplierV);
        PlayerRigidbody.AddForce(orientation.transform.right * x * moveSpeed * Time.deltaTime * multiplier);
    }


    private float desiredX;
    public void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * sensMultiplier;

        //Find current look rotation
        Vector3 rot = playerCam.transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;

        //Rotate, and also make sure we dont over- or under-rotate.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
        orientation.transform.localRotation = Quaternion.Euler(0, desiredX, 0);
    }

    /// <summary>
    /// Find the velocity relative to where the player is looking
    /// Useful for vectors calculations regarding movement and limiting movement
    /// </summary>
    /// <returns></returns>
    public Vector2 FindVelRelativeToLook()
    {
        float lookAngle = orientation.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(PlayerRigidbody.velocity.x, PlayerRigidbody.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = new Vector3(PlayerRigidbody.velocity.x, 0, PlayerRigidbody.velocity.z).magnitude;

        float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }

    private void CounterMovement(float x, float y, Vector2 mag)
    {


        //Counter movement
        if (Math.Abs(mag.x) > threshold && Math.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0))
        {
            PlayerRigidbody.AddForce(moveSpeed * orientation.transform.right * Time.deltaTime * -mag.x * counterMovement);
        }
        if (Math.Abs(mag.y) > threshold && Math.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0))
        {
            PlayerRigidbody.AddForce(moveSpeed * orientation.transform.forward * Time.deltaTime * -mag.y * counterMovement);
        }

        //Limit diagonal running. This will also cause a full stop if sliding fast and un-crouching, so not optimal.
        if (Mathf.Sqrt((Mathf.Pow(PlayerRigidbody.velocity.x, 2) + Mathf.Pow(PlayerRigidbody.velocity.z, 2))) > maxSpeed)
        {
            float fallspeed = PlayerRigidbody.velocity.y;
            Vector3 n = PlayerRigidbody.velocity.normalized * maxSpeed;
            PlayerRigidbody.velocity = new Vector3(n.x, fallspeed, n.z);
        }
    }


    //Applies upwards force to player
    public void Jump()
    {
            //Add jump forces
            PlayerRigidbody.AddForce(Vector2.up * jumpForce * 1.5f);
            PlayerRigidbody.AddForce(normalVector * jumpForce * 0.5f);
            //If jumping while falling, reset y velocity.
            Vector3 vel = PlayerRigidbody.velocity;
            if (PlayerRigidbody.velocity.y < 0.5f)
                PlayerRigidbody.velocity = new Vector3(vel.x, 0, vel.z);
            else if (PlayerRigidbody.velocity.y > 0)
                PlayerRigidbody.velocity = new Vector3(vel.x, vel.y / 2, vel.z);
    }


    //


}
