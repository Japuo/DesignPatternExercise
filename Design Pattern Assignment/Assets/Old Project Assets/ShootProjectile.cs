using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    GameObject prefab;
    public float bulletSpeed = 10f;
    public float bulletFrequencyThreshold = 60f;
    private float bulletFrequencyTimer = 0f;
    private float timerStart = 0f;

    void Update()
    {
        bulletFrequencyTimer = bulletFrequencyTimer + timerStart;

        if(bulletFrequencyTimer == bulletFrequencyThreshold || Input.GetMouseButton(0) == false)
        {
            bulletFrequencyTimer = 0f;
        }

        if (Input.GetMouseButton(0))
        {
            timerStart = 1f;
        }
        else
        {
            timerStart = 0f;
        }

        if (Input.GetMouseButton(0) && bulletFrequencyTimer == 3f)
        {
            GameObject projectile = ObjectPool.SharedInstance.GetPooledObject();
            if (projectile != null)
            {
                projectile.transform.position = transform.position + Camera.main.transform.forward * 1.5f;
                projectile.SetActive(true);
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * bulletSpeed;
            }
        }
    }
}
