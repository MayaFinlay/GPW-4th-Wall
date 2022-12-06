using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractState : MonoBehaviour
{
    public bool interactingWithPC;

    // Start is called before the first frame update
    void Start()
    {
        interactingWithPC = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !interactingWithPC)
        {
            //Time.timeScale = 0;
            interactingWithPC = !interactingWithPC;

            Cursor.lockState = CursorLockMode.None;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && interactingWithPC)
        {
            //Time.timeScale = 1;
            interactingWithPC = !interactingWithPC;

            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
    }
}
