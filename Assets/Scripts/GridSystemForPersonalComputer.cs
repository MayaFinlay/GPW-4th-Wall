using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridSystemForPersonalComputer : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public string edgeTag = "EdgeDropArea";
    public string cornerTag = "CornerDropArea";
    public string spawnPoint;
    int screenSize;
    int cornerSize;
    int edgeSize;

    public bool gruntFireState;
    public GameObject grunt;
    public bool sniperFireState;
    public GameObject sniper;
    public bool tankFireState;
    public GameObject tank;

    public GameObject projectile;

    public Material spawnable;
    public Material spawnablent;

    public int radius;

    public List<GameObject> screenGrid = new List<GameObject>();
    public List<GameObject> cornerScreenGrid = new List<GameObject>();
    public List<GameObject> edgeScreenGrid = new List<GameObject>();
    public List<GameObject> fullScreen = new List<GameObject>();
    public List<GameObject> gridToPaint = new List<GameObject>();

    private void Start()
    {
        gruntFireState = false;
        sniperFireState = false;
        tankFireState = false;
    }

    private void Update()
    {
        var rayOrigin = UnityEngine.Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - UnityEngine.Camera.main.transform.position;
        RaycastHit hitInfo;
        if ((Input.GetKeyDown(KeyCode.Mouse1) == true) && (gruntFireState == false || sniperFireState == false || tankFireState || false))
        {
            if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
            {
                if (hitInfo.transform.tag == "GruntToken")
                {
                    gruntFireState = true;
                    sniperFireState = false;
                    tankFireState = false;
                }
                if (hitInfo.transform.tag == "SniperToken")
                {
                    gruntFireState = false;
                    sniperFireState = true;
                    tankFireState = false;
                }
                if (hitInfo.transform.tag == "TankToken")
                {
                    gruntFireState = false;
                    sniperFireState = false;
                    tankFireState = true;
                }
            }            
        }      
        
        if((Input.GetKeyDown(KeyCode.Mouse1) == true) && (gruntFireState == true && Physics.Raycast(rayOrigin, rayDirection, out hitInfo)))
        {            
            if (hitInfo.transform.tag == destinationTag || hitInfo.transform.tag == edgeTag || hitInfo.transform.tag == cornerTag)
            {
                GruntFire(hitInfo.transform.gameObject.GetComponent<NodeHandler>().node.transform.position);
            }            
        }

        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            gruntFireState = false;
            sniperFireState = false;
            tankFireState = false;
        }
    }

    void OnMouseUp()
    {
        var rayOrigin = UnityEngine.Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - UnityEngine.Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == destinationTag || hitInfo.transform.tag == edgeTag || hitInfo.transform.tag == cornerTag)
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

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("DropArea"))
        {
            screenGrid.Add(fooObj);
            fullScreen.Add(fooObj);
        }
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("EdgeDropArea"))
        {
            edgeScreenGrid.Add(fooObj);
            fullScreen.Add(fooObj);
        }
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("CornerDropArea"))
        {
            cornerScreenGrid.Add(fooObj);
            fullScreen.Add(fooObj);
        }

        screenSize = screenGrid.Count();
        edgeSize = edgeScreenGrid.Count();
        cornerSize = cornerScreenGrid.Count();

        for (i = 0; i < screenSize; i++)
        {
            screenGrid[i].GetComponent<MeshRenderer>().material = spawnablent;
        }
        for (i = 0; i < edgeSize; i++)
        {
            edgeScreenGrid[i].GetComponent<MeshRenderer>().material = spawnablent;
        }
        for (i = 0; i < cornerSize; i++)
        {
            cornerScreenGrid[i].GetComponent<MeshRenderer>().material = spawnablent;
        }

        if (col.gameObject.tag == destinationTag || col.gameObject.tag == edgeTag || col.gameObject.tag == cornerTag)
        {
            spawnPoint = col.gameObject.name;
        }

        fullScreen.Sort((x, y) => Vector3.Distance(transform.position, x.transform.position).CompareTo(Vector3.Distance(transform.position, y.transform.position)));
/*
        if (col.gameObject.tag == destinationTag)
        {
            for (k = 0; k < 9; k++)
            {
                fullScreen[k].GetComponent<MeshRenderer>().material = spawnable;
            }
        }

        if (col.gameObject.tag == edgeTag)
        {
            for (k = 0; k < 6; k++)
            {
                fullScreen[k].GetComponent<MeshRenderer>().material = spawnable;
            }
        }
        if (col.gameObject.tag == cornerTag)
        {
            for (k = 0; k < 4; k++)
            {
                fullScreen[k].GetComponent<MeshRenderer>().material = spawnable;
            }
        }
        fullScreen.Clear();
*/
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = UnityEngine.Camera.main.WorldToScreenPoint(transform.position).z;
        return UnityEngine.Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    void GruntFire(Vector3 lookDirection)
    {
        grunt.transform.LookAt(lookDirection);
        Rigidbody rb = Instantiate(projectile, grunt.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
    }
}


