using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ShortSheriffHitbox : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Killed");
            Destroy(enemy);
        }
    }

    void Update()
    {
        
    }
}
