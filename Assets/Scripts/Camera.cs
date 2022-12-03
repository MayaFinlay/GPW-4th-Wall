using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float sensitivity = 100;
    public float xRotation = 0;
    public Transform player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXCoord = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYCoord = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseYCoord;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseXCoord);
    }
}
