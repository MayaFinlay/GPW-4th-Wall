using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public GameObject token;
    public GameObject ally;

    private void OnMouseUpAsButton()
    {
        var rayOrigin = UnityEngine.Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - UnityEngine.Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == "Up")
            {
                
            }
            if (hitInfo.transform.tag == "Down")
            {
                
            }
            if (hitInfo.transform.tag == "Left")
            {
                
            }
            if (hitInfo.transform.tag == "Right")
            {
                
            }
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = UnityEngine.Camera.main.WorldToScreenPoint(transform.position).z;
        return UnityEngine.Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
