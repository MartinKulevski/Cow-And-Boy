using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OffCamera : MonoBehaviour
{
    // Detects manually if obj is being seen by the main camera

    private Collider2D col;

    GameObject obj;
    Collider2D objCollider;



    Camera cam;
    Plane[] planes;



    void Start()
    {
        col = GetComponent<Collider2D>();
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        objCollider = GetComponent<Collider2D>();
        col.enabled = false;
        StartCoroutine(WaitToTurnOnCollider());
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
    IEnumerator WaitToTurnOnCollider()
    {
        yield return new WaitForSeconds(0.2f);
        col.enabled = true;
    }
}