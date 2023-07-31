using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulletDown : MonoBehaviour
{
    public Text ammoText;
    public int ammoCount = 5;
    public GameObject gameOverScreen;

    private void Start()
    {
        ammoText.text = "Ammo: " + ammoCount;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoCount > 0)
            {
                ammoCount--;
                UpdateAmmoText();
            }
            else
            {
                StartCoroutine(WaitForGameOverScreen());
            }
        }
    }

    IEnumerator WaitForGameOverScreen()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet Refill"))
        {
            ammoCount+= 1;
            UpdateAmmoText();
        }
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }

    
}
