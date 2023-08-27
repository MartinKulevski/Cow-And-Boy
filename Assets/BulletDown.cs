using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulletDown : MonoBehaviour
{
    public Text ammoText;
    public int ammoCount = 5;

    private Music musicScript; // Reference to the Music script

    public GameObject gameOverScreen;
    public GameObject BulletRefill;

    public Image spriteRenderer;
    public Sprite[] ammoUI;
    public int currentAmmoUI;


    private void Start()
    {
        ammoText.text = "Ammo: " + ammoCount;

        // Find the Music script in the scene
        
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

    private IEnumerator WaitForGameOverScreen()
    {
        yield return new WaitForSeconds(1.5f);

        gameOverScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet Refill"))
        {
            ammoCount += 1;
            UpdateAmmoText();
            Destroy(BulletRefill);
        }
    }

    private void UpdateAmmoText()
    {
        if(ammoCount == 5)
        {
            spriteRenderer.sprite = ammoUI[0];
        }
        if (ammoCount == 4)
        {
            spriteRenderer.sprite = ammoUI[1];
        }
        if (ammoCount == 3)
        {
            spriteRenderer.sprite = ammoUI[2];
        }
        if (ammoCount == 2)
        {
            spriteRenderer.sprite = ammoUI[3];
        }
        if (ammoCount == 1)
        {
            spriteRenderer.sprite = ammoUI[4];
        }
        if (ammoCount == 0)
        {
            spriteRenderer.sprite = ammoUI[5];
        }
    }
}
