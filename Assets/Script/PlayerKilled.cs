using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKilled : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Dead");
                Destroy(Player);
            }
        }
    }
}