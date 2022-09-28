using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChacter : MonoBehaviour
{

    private int _health;

    private void Start()
    {
        _health = 5;
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("health " + _health);
    }
    

}
