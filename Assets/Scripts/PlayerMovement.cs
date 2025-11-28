using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 60f;
    public float sensitivity = 2f;

    private Rigidbody rb;
    private float rotationX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mirar con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(0, mouseX, 0);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    void FixedUpdate()
    {
        // Movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}