using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimalDetector : MonoBehaviour
{
    public TextMeshProUGUI mensajeUI;
    public Camera cam;
    public float detectDistance = 500f;

    public int score = 0;

    private GameObject animalEnMira;

    void Update()
    {
        DetectarAnimal();

        // SOLO si el jugador presiona E intenta alimentar
        if (Input.GetKeyDown(KeyCode.E))
        {
            IntentarAlimentar();
        }
    }

    void DetectarAnimal()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectDistance))
        {
            if (hit.collider.CompareTag("Animal"))
            {
                animalEnMira = hit.collider.gameObject;
                return;
            }
        }

        // Si no golpea un animal, limpiamos
        animalEnMira = null;
    }

    void IntentarAlimentar()
    {
        PlayerInventory inv = GetComponent<PlayerInventory>();

        // 1. ¿Hay vaca en mira?
        if (animalEnMira == null)
        {
            mensajeUI.text = "No estás mirando a la vaca.";
            return;
        }

        // 2. ¿Tiene manzana?
        if (!inv.hasApple)
        {
            mensajeUI.text = "No tenés manzana para alimentar a la vaca.";
            return;
        }

        // 3. Si todo está bien → alimentar
        score++;
        inv.hasApple = false;

        mensajeUI.text = "¡Alimentaste a la vaca! - Puntos: " + score;
    }
}