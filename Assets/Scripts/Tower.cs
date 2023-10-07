using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Tower : MonoBehaviour
{
    /*public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public bool isPlaced;
    //public float bulletSpeed = 10f;
    public float cooldown = 1f; // Cooldown time in seconds
    public bool canShoot = true; // Flag to check if shooting is allowed
    public Transform bulletSpawnPoint;*/

    public bool isPlaced;
    public GameObject infoPanel;
    public Scan scan;


    void Start()
    {
        //bulletSpawnPoint = transform.Find("BulletSpawnPoint"); // Assuming you have a child object for spawning bullets
        infoPanel.SetActive(false);
    }

    void Update()
    {
        if (isPlaced && scan.currentValue == 100)
        {
            infoPanel.SetActive(true);
        }else
        {
            infoPanel.SetActive(false);
        }
       /* if (isPlaced && canShoot)
        {
            if (this.gameObject.tag == "TurretA")
            {
                ShootBulletA();
            }
            if (this.gameObject.tag == "TurretB")
            {
                ShootBulletB();
            }
            if (this.gameObject.tag == "TurretC")
            {
                ShootBulletA();
            }
            StartCoroutine(CooldownTimer());
        }*/
    }
    public void StartTowerAction()
    {
        isPlaced = true;
        Debug.Log("isPlaced");
       
    }

    public void ExitTowerAction()
    {
        isPlaced = false;
        Debug.Log("isOut");

    }

   /* public void ShootBulletA()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            /*Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
        }
    }
    public void ShootBulletB()
    {
        if (bulletPrefab2 != null && bulletSpawnPoint != null)
        {

            GameObject newBullet2 = Instantiate(bulletPrefab2, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            /*Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
        }
    }

    public IEnumerator CooldownTimer()
    {
        canShoot = false; // Prevent shooting during cooldown
        yield return new WaitForSeconds(cooldown);
        canShoot = true; // Allow shooting again after cooldown
    }*/



   
}
