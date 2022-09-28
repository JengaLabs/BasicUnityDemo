using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{


    //Link the prefab of an enemy
    [SerializeField] private GameObject _enemyPrefab;
    //Keep track of the enemy instance in the scene
    private GameObject _enemy;


    private void Update()
    {
        
        //Check if enemy exist
        if(_enemy == null)
        {
            //Instantiate the enemy 
            _enemy = Instantiate(_enemyPrefab) as GameObject;
            //set the enemy position
            _enemy.transform.position = new Vector3(0, 1, 0);
            //Create a random angle
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

        }
    }

}
