using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    [SerializeField] private GameObject _fireballPrefab;
    //The current fireball
    private GameObject _fireball;


    public float speed = 3.0f;
    //How far AI needs to see ahead
    public float obstacleRange = 5.0f;

    /// <summary>
    /// Could use a fsm for AI state instead
    /// </summary>

    //Track if alive
    private bool _alive; 




    private void Start()
    {
        _alive = true;
    }


    // Update is called once per frame
    void Update()
    {

        if (_alive)
        {
            //Move forward continuously every frame
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        //Create a ray that moves forward from ai position
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        //Check a circumference around the ray
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            //Store the GameObject
            GameObject hitObject = hit.transform.gameObject;

            //Check if player
            if (hitObject.GetComponent<PlayerChacter>())
            {
                //Check if AI has a fireball
                if(_fireball == null)
                {
                    //Create instance of fireball
                    _fireball = Instantiate(_fireballPrefab) as GameObject;
                    //Place the fireball infront of the AI
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    //Set the rotation in the same direction
                    _fireball.transform.rotation = transform.rotation;
                }
            }

            //Check in range
            else if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                //Turns a random direction
                transform.Rotate(0, angle, 0);
            }
        }
    }

    /// <summary>
    /// Set if AI is alive
    /// </summary>
    /// <param name="alive"></param>
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

}
