using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject gun;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private Animator gunExplosionAnimator;

    private void Awake()
    {
        gunExplosionAnimator = gun.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gunExplosionAnimator.SetTrigger("FireTrigger");
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gun.transform.up * bulletForce, ForceMode2D.Impulse);
    }
}
