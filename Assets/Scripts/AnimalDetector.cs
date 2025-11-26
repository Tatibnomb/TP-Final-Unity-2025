using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDetector : MonoBehaviour
{
    public Camera cam;
    public float detectDistance = 3f;

    public int score = 0;

    private bool animalDetectado = false;

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectDistance))
        {
            if (hit.collider.CompareTag("Animal"))
            {
                PlayerInventory inv = GetComponent<PlayerInventory>();

                if (inv.hasApple && !animalDetectado)
                {
                    // SOLO PASA SI REALMENTE TENÉS MANZANA
                    score++;
                    inv.hasApple = false;
                    animalDetectado = true;

                    Debug.Log("Alimentaste al animal — Puntos: " + score);
                }
                else if (!inv.hasApple && !animalDetectado)
                {
                    Debug.Log("No tenés manzana");
                }
            }
            else
            {
                animalDetectado = false;
            }
        }
        else
        {
            animalDetectado = false;
        }
    }
}