using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndFourth : MonoBehaviour
{

    //Speed the object moves
    public float speed = 1.0f;

    //Positions the object moves between
    public float maxZ = 1.0f;
    public float minZ = -1.0f;

    //Which direciton is the object currently moving in
    private int _direction = 1;


    private void Update()
    {
        transform.Translate(0, 0, _direction * speed * Time.deltaTime);

        bool bounced = false;
        if (transform.localPosition.z >= maxZ || transform.localPosition.z <= minZ)
        {
            _direction = -_direction;
            bounced = true;   
        }
        


        transform.Translate(0, 0, _direction * speed * Time.deltaTime);




    }



}
