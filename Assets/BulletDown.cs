using UnityEngine;
using UnityEngine.UI;

public class BulletDown : MonoBehaviour
{
    public Text ammoText;
    public int ammoCount = 5;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoCount > 0)
            {
                ammoCount--;
                UpdateAmmoText();
            }
        }
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }
}
