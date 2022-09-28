using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    //Mouse sensitivity
    public float mouseSense;

    //Rotation clamp
    private float _maxRotation = 50f;
    private float _minRotation = 70f;

    //Rotation
    float _rotationX;


    

    



    void Update()
    {


        _rotationX -= Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        _rotationX = Mathf.Clamp(_rotationX, -_minRotation, _maxRotation);

        transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);


        
    }
}
