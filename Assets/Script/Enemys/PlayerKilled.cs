using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKilled : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GameOver;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemy"))
    {
            gameObject.SetActive(GameOver);
    }
}
}