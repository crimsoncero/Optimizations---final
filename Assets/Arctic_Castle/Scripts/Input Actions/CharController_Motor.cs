using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : MonoBehaviour
{
    public float speed = 2f;
    public float sensitivity = 10.0f;
    public bool webGLRightClickRotation = true;

    [SerializeField] private CharacterController character;
    [SerializeField] private Camera cam;
    private float moveFB, moveLR;
    private float rotX, rotY;

    void Start()
    {
        if (character == null)
            Debug.LogWarning("CharacterController reference is not assigned!");
        if (cam == null)
            Debug.LogWarning("Camera reference is not assigned!");

#if UNITY_EDITOR
        webGLRightClickRotation = false;
        sensitivity *= 2;
#endif
    }

    void Update()
    {
        moveFB = Input.GetAxis("Horizontal") * speed;
        moveLR = Input.GetAxis("Vertical") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movement = new Vector3(moveFB, -9.8f, moveLR) * Time.deltaTime;

        if (webGLRightClickRotation && Input.GetKey(KeyCode.Mouse0) || !webGLRightClickRotation)
        {
            CameraRotation(rotX, rotY);
        }

        movement = transform.rotation * movement;
        if (character != null)
        {
            character.Move(movement);
        }
    }

    void CameraRotation(float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);

        rotY = Mathf.Clamp(rotY, -80f, 80f);

        if (cam != null)
        {
            cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
        }
    }
}
