using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ShortSheriffHitbox : MonoBehaviour
{

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //When player touches the hitbox, the player will beocome destroyed. 
            Destroy(transform.parent.gameObject);
        }
    }
}