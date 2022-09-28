using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float speed = 10.0f;
    public int damage = 1;

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerChacter player = other.GetComponent<PlayerChacter>();
        if(player != null)
        {
            player.Hurt(damage);
            Debug.Log("Player hit");

        }

        Destroy(this.gameObject);
    }

}
