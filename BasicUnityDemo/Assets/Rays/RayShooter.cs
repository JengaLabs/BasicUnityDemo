using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{


    //reference to camera
    private Camera _camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _camera = GetComponent<Camera>();    
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        //Creates a gui for crosshair
        GUI.Label(new Rect(posX, posY,size,size), "*");
    }


    void Update()
    {

        //Check for input
        if (Input.GetMouseButtonDown(0))
        {
            //Get the middle of the camera perspective
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            //Create a ray from origin point
            Ray ray = _camera.ScreenPointToRay(point);
            //Store the hit value
            RaycastHit hit;

            //Chest if ray hit
            if(Physics.Raycast(ray, out hit))
            {
                //store the object hit
                GameObject hitObject = hit.transform.gameObject;
                //check target has reactivetarget component
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                //If object has the component then objecti s target
                if(target != null)
                {
                    //Call a react
                    target.ReactToHit();

                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));

                }



            }
            


        }
        
    }

    //Leaves a sphere for one second in given position
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }

}
