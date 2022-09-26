using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{


    //Roation axes stored instead of using variables
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1, 
        MouseY = 2
    }

    // The axes mouse will rotate based on 
    public RotationAxes axes = RotationAxes.MouseXAndY;

    //Mouse sensitivty for looking
    public float mouseSensitivity = 4.0f;

    //Maximum and minimum rotation on the vertical value 
    private float _rotationClamp = 45f;

    //Store the current vertical angle
    private float _rotationX = 0;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        #region Disallow physics rotation
        //Get rigidbody
        Rigidbody body = GetComponent<Rigidbody>();
        //Freeze all rotations 
        body.freezeRotation = true;

        #endregion
    }



    void Update()
    {
        


        //Different types of mouse look
        if(axes == RotationAxes.MouseX)
        {
            // Horizontal rotation here
            transform.Rotate(0, Input.GetAxis("Mouse X")* mouseSensitivity, 0);

        }
        else if(axes == RotationAxes.MouseY) 
        {
            //Get vertical rotation input 
            _rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            //Clamp value
            _rotationX = Mathf.Clamp(_rotationX, -_rotationClamp - 20, _rotationClamp );

            

            //Perform transformation and keep same y rotation
            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        
        }
        else
        {

            //Get vertical rotation input 
            _rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            //Clamp value
            _rotationX = Mathf.Clamp(_rotationX, -_rotationClamp - 20, _rotationClamp);

            //Perform rotation
            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity, 0);

        }
    }
}
