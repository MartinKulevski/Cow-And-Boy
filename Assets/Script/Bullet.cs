using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    private Vector2 Cursor;   
    void Start()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 bulletStartPosition = transform.position;
        Cursor = (mouseWorldPosition - bulletStartPosition).normalized;
        
         float angle = Mathf.Atan2(Cursor.y, Cursor.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);



    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Cursor * speed * Time.deltaTime); //Makes bullet move forward
        Destroy(gameObject, 2f);   //Destroys bullet after 2 seconds
    }
}
