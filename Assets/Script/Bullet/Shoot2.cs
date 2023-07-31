using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour
{
    public Camera mainCamera;                    
    public GameObject projectilePrefab;           
    public float projectileForce = 10f;
    public BulletDown bulletDown;

    //Notes :)
    //Mathf.Atan2 = Calculates the angle from a line. Essentially if the line was pointing up,
    //Mathf.Atan2 will find out the angle, it will tell you where it will be

    //Mathf.Rad2Deg = Think of it like a calculator that converts the angle from Radians to Degrees,
    //This helps Mathf.Atan2 find out the angle and help it find the rotation needed for the raycast
    //Quaternion.AngleAxis = A command that tells the object on how much to turn. You tell how much to rotate, It will rotate for you
    //Mathf.Atan2 helps us find the angle thats needed to turn the bullet, Mathf.Rad2Deg changes the measurement to degrees, making it easier for us to know where we want it to turn
    //Quaternion.AngleAxis will rotate the bullet so it faces where the direction will go.

    private void Update()
    {
        if(bulletDown.ammoCount>0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Raycast from camera to mouse position
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = mousePosition - (Vector2)transform.position;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity);

                if (hit)
                {
                    // Creates a cool line in the Scene view, to see where the bullet will shoot
                    Debug.DrawRay(transform.position, direction, Color.red, 1f);

                    // Spawn gameobject projectile on the player.
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    Destroy(projectile, 2);

                    // Rotates the projectile to face the shooting direction

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    // Make bullet move forward
                    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                    rb.AddForce(direction.normalized * projectileForce, ForceMode2D.Impulse);



                }
            }
        }
        else
        {
            return;
        }

    }
}






