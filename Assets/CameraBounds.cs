using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float raycastDistance = 10f; // Distance for raycasting

    private float nearClipPlaneDistance;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        nearClipPlaneDistance = Mathf.Abs(mainCamera.transform.position.z - mainCamera.nearClipPlane);
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;

        // Perform raycasts to determine bounds based on collisions with objects tagged as "Ground"
        float clampedX = cameraPosition.x;
        float clampedY = cameraPosition.y;

        RaycastHit hit;

        // Check left bound
        if (Physics.Raycast(cameraPosition, Vector3.left, out hit, raycastDistance) && hit.collider.CompareTag("Ground"))
        {
            clampedX = Mathf.Max(clampedX, hit.point.x + nearClipPlaneDistance);
        }

        // Check right bound
        if (Physics.Raycast(cameraPosition, Vector3.right, out hit, raycastDistance) && hit.collider.CompareTag("Ground"))
        {
            clampedX = Mathf.Min(clampedX, hit.point.x - nearClipPlaneDistance);
        }

        // Check bottom bound
        if (Physics.Raycast(cameraPosition, Vector3.down, out hit, raycastDistance) && hit.collider.CompareTag("Ground"))
        {
            clampedY = Mathf.Max(clampedY, hit.point.y + nearClipPlaneDistance);
        }

        // Check top bound
        if (Physics.Raycast(cameraPosition, Vector3.up, out hit, raycastDistance) && hit.collider.CompareTag("Ground"))
        {
            clampedY = Mathf.Min(clampedY, hit.point.y - nearClipPlaneDistance);
        }

        transform.position = new Vector3(clampedX, clampedY, cameraPosition.z);
    }
}
