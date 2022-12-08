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
    int screenSize;

    public Material spawnable;
    public Material spawnablent;

    public GameObject node;
    public Vector3 currentNode;

    public int radius;

    public List<GameObject> screenGrid = new List<GameObject>();
    public List<GameObject> gridToPaint = new List<GameObject>();


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
        int i = 0;
        int k = 0;
        currentNode = transform.position;

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("DropArea"))
        {
            screenGrid.Add(fooObj);
        }

        screenSize = screenGrid.Count();
        for (i = 0; i < screenSize; i++)
        {
            screenGrid[i].GetComponent<MeshRenderer>().material = spawnablent;
        }

        if (col.gameObject.tag == destinationTag)
        {
            spawnPoint = col.gameObject.name;
        }

        screenGrid.Sort((x, y) => Vector3.Distance(transform.position, x.transform.position).CompareTo(Vector3.Distance(transform.position, y.transform.position)));

        for (k = 0; k < 9; k++)
        {
            screenGrid[k].GetComponent<MeshRenderer>().material = spawnable;
        }
        screenGrid.Clear();
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = UnityEngine.Camera.main.WorldToScreenPoint(transform.position).z;
        return UnityEngine.Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

}
    
    
