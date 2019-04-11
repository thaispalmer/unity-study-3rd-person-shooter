using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifeSpan = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        Physics.IgnoreCollision(
            bullet.GetComponent<Collider>(),
            bulletSpawn.parent.GetComponent<Collider>()
        );

        bullet.transform.position = bulletSpawn.position;

        bullet.transform.rotation = Quaternion.Euler(
            bulletSpawn.eulerAngles.x + 90,
            bulletSpawn.eulerAngles.y,
            bulletSpawn.eulerAngles.z
        );

        bullet.GetComponent<Rigidbody>().AddForce(
            bulletSpawn.forward * bulletSpeed,
            ForceMode.Impulse
        );

        StartCoroutine(DestroyBulletAfterLifeSpan(bullet));
    }

    private IEnumerator DestroyBulletAfterLifeSpan(GameObject bullet)
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(bullet);
    }
}
