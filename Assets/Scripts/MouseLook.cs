using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerTransform;

    private float cameraRotationY = 90f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        cameraRotationY = Mathf.Clamp(cameraRotationY - mouseY, -90f, 90f);
        transform.localRotation = Quaternion.Euler(cameraRotationY, 0f, 0f);

        playerTransform.Rotate(Vector3.up, mouseX);
    }
}
