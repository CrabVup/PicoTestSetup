using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool isPlaced = false;
    //public float bulletSpeed = 10f;
    public float cooldown = 1f; // Cooldown time in seconds
    public bool canShoot = true; // Flag to check if shooting is allowed
    public Transform bulletSpawnPoint;

    void Start()
    {
        //bulletSpawnPoint = transform.Find("BulletSpawnPoint"); // Assuming you have a child object for spawning bullets
    }

    void Update()
    {
        if (isPlaced == true && canShoot)
        {
            ShootBullet();
            StartCoroutine(CooldownTimer());
        }
    }
    public void StartTowerAction()
    {

        Debug.Log("isPlaced");
        isPlaced = true;
    }

    public void ShootBullet()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            /*Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
            }*/
        }
    }

    public IEnumerator CooldownTimer()
    {
        canShoot = false; // Prevent shooting during cooldown
        yield return new WaitForSeconds(cooldown);
        canShoot = true; // Allow shooting again after cooldown
    }

    // Rest of your Tower script...
}
