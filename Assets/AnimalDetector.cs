using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDetector : MonoBehaviour
{
    public int score = 0;
    PlayerInventory inv;

    void Start()
    {
        inv = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag("Animal"))
            {
                if (inv.hasApple)
                {
                    score++;
                    inv.hasApple = false;
                    Debug.Log("¡Punto sumado! Score: " + score);
                }
            }
        }
    }
}