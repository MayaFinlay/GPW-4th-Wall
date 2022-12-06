using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemForPersonalComputer : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public string spawnPoint;

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        var rayOrigin = UnityEngine.Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - UnityEngine.Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == destinationTag)
        {
            spawnPoint = col.gameObject.name;
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = UnityEngine.Camera.main.WorldToScreenPoint(transform.position).z;
        return UnityEngine.Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}