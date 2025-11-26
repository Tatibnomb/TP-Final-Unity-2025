using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletForce = 700f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

            b.GetComponent<Bullet>().player = GetComponent<PlayerInventory>();

            Rigidbody rb = b.GetComponent<Rigidbody>();
            rb.AddForce(shootPoint.forward * bulletForce, ForceMode.Impulse);
        }
    }
}