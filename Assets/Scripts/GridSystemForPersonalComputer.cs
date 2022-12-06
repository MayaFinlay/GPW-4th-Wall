using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridSystemForPersonalComputer : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public string spawnPoint;
    public int screenSize;

    public Material Spawnable;
    public Material Spawnablent;

    public List<GameObject> screenGrid = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("DropArea"))
        {
            screenGrid.Add(fooObj);
        }
    }

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
/*
    public void OntriggerStay(Collider col)
    {
        int i = 0;
        screenSize = screenGrid.Count();

        for (i = 0; i < (screenSize); i++)
        {
            if (col.gameObject.tag == destinationTag)
            {
                screenGrid[i].GetComponent<MeshRenderer>().material = Spawnable;
            }
            else
            {
                screenGrid[i].GetComponent<MeshRenderer>().material = Spawnablent;
            }
        }
    }
*/
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = UnityEngine.Camera.main.WorldToScreenPoint(transform.position).z;
        return UnityEngine.Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}