using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject gun;
    public GameObject bulletPrefab;
    public GameObject gunExplosionEffect;
    public float gunExplosionEffectDuration = 0.1f;
    public float bulletForce = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject effect = Instantiate(gunExplosionEffect, gun.transform.position, gun.transform.rotation, transform);
            Destroy(effect, gunExplosionEffectDuration);
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
