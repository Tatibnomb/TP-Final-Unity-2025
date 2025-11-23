using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerInventory>().hasApple = true;

            Destroy(gameObject);
        }
    }
}