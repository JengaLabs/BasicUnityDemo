using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{

    public float playerSpeed = 6.0f;

    public float gravity = -9.8f;

    public float mouseSense;

    private CharacterController _charController;


    private void Start()
    {
        _charController = GetComponent<CharacterController>();

    }


    private void Update()
    {

        Movement();

    }

    private void Movement()
    {
        //get x mouse value
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime, 0);



        //Get x and y movment values
        float deltaX = Input.GetAxis("Horizontal") * playerSpeed;
        float deltaZ = Input.GetAxis("Vertical") * playerSpeed;


        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //Limits diagonal movment horizontal
        movement = Vector3.ClampMagnitude(movement, playerSpeed);

        //Allow gravity to go past clamp
        movement.y = gravity;

        //Keep movement relative to time
        movement *= Time.deltaTime;

        //Changes vector from local to global coordinates
        movement = transform.TransformDirection(movement);

        //Tells the character controller to move 
        _charController.Move(movement);
    }



}
