using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OffCamera : MonoBehaviour
{
    // Detects manually if obj is being seen by the main camera



    GameObject obj;
    Collider2D objCollider;



    Camera cam;
    Plane[] planes;



    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        objCollider = GetComponent<Collider2D>();
    }



    void Update()
    {
        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            Debug.Log("Bullet" + " has been detected!");

        }
        else
        {
            Debug.Log("Nothing has been detected");
            Destroy(gameObject);
        }
    }
}