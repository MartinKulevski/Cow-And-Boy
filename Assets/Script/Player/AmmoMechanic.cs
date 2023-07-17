using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AmmoMechanic : MonoBehaviour
{
    public Text AmmoText;
    private int ammoCount = 5;
    private bool canShoot = true;

    private float shootDelay = 0.5f;
    private bool isCooldown = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && ammoCount > 0 && !isCooldown)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        ammoCount--;
        UpdateAmmoText();

        if (ammoCount <= 0)
        {
            StartCoroutine(RestartSceneAfterDelay(0.5f));
        }
        else
        {
            isCooldown = true;
            yield return new WaitForSeconds(shootDelay);
            isCooldown = false;
        }
    }

    IEnumerator RestartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateAmmoText()
    {
        AmmoText.text = "Ammo: " + ammoCount.ToString();
    }

    void Start()
    {
        UpdateAmmoText();
    }
}
