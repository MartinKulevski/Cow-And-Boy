using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot3 : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject projectilePrefab;
    public float projectileForce = 10f;
    public BulletDown bulletDownScript;

    private void Update()
    {
        if (bulletDownScript.ammoCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - mainCamera.transform.position.z));

        Vector3 shootingDirection = worldMousePosition - transform.position;
        shootingDirection.z = 0f;

        shootingDirection.Normalize();

        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Destroy(projectile, 2f);

        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingDirection * projectileForce, ForceMode2D.Impulse);
    }
}
