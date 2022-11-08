using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Simple script that keeps camera attached to player position
public class PlayerCamera : MonoBehaviour
{

    //Public access to the players transform for tracking
    public Transform player;


    void Update()
    {
        //transform.position = player.transform.position;
    }
}
