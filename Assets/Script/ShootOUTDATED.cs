using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Shoot : MonoBehaviour
{
    //Vector3.Lerp is making an object go one point to another smoothly.
    
    private bool isAiming;
    public Texture2D Crosshair;
    private Vector2 cursorHotspot;
    public Camera Camera;
    public Transform Player;
    public float smoothness = 10f; // just makes the camera feel nicer when moving around, combined with Time.deltatime
    public float maxDistance = 5f; //How far the cursor can go from the player
    private Vector3 cameraOffset;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject mousePosition;


    // Start is called before the first frame update


 
    

    
    
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Cursor.SetCursor(Crosshair, cursorHotspot, CursorMode.Auto);
        cursorHotspot = new Vector2(Crosshair.width, Crosshair.height);
    }

    private void Raycast()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = new Ray(Camera.transform.position, worldPosition);
        Debug.DrawRay(Camera.transform.position, worldPosition);
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpawn.transform.LookAt(Input.mousePosition);

        Raycast();

        //if (Input.GetMouseButton(1)) // If right click is pressed
        //{
        //    isAiming = !isAiming; //Toggle aiming mode
        //}


        //if (isAiming == true)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;

        //    Vector3 offset = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0); // Gets mouse position
        //    Vector3 clampedOffset = Vector3.ClampMagnitude(offset, maxDistance); //Uses clamp magnitude to clamp the mouse position to the distance. ClampmMagnitude means the length its clamped at
        //    Vector3 targetPosition = Player.position + clampedOffset; //Target position is the camera, locking itself to the player and the distance

        //    Vector3 smoothPosition = Vector3.MoveTowards(Camera.transform.position, targetPosition, smoothness * Time.deltaTime); //smoothly moves torwards where the mouse is

        //    Camera.transform.position = smoothPosition; //Camera position = where smoothPosition will go
        //}
        //else
        //{
        //    Cursor.lockState = CursorLockMode.Locked; //Cursor Locks
        //    Cursor.visible = false; //Cursor invisible

        //    Vector3 targetPosition = Player.position + cameraOffset; //Makes target position equal to the player.position as well as the camera offset coords
        //    Vector3 smoothPosition = Vector3.MoveTowards(Camera.transform.position, targetPosition, smoothness * Time.deltaTime); //Code to make camera return back to player and make it smoother 

        //    Camera.transform.position = smoothPosition; //Return camera position to where smooth position will go
        //}


        if (isAiming == true && Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
        }
    }
}
