using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public PlayerInventory player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            Debug.Log("La manzana fue alcanzada por la bala");

            player.hasApple = true;
            Debug.Log("Ahora tenés manzana = " + player.hasApple);

            Destroy(other.gameObject); // destruye la manzana
            Destroy(gameObject);       // destruye la bala
        }
    }
}