using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class snapToGrid : MonoBehaviour
{
    int snapListSize;
    int pushableSize;
    public List<GameObject> snapPoints = new List<GameObject>();
    public List<GameObject> pushable = new List<GameObject>();
    public List<GameObject> blacklist = new List<GameObject>();
    public float distance;
    public float minDistance;
    public Vector3 closestSnap;

    void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("SnapPoints"))
        {
            snapPoints.Add(fooObj);            
        }
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Pushable"))
        {
            pushable.Add(fooObj);
        }
        GridSnap();
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            GridSnap();
        }
        if (blacklist.Contains(col.gameObject))
        {
            blacklist.Remove(col.gameObject);
            for (int i = 0; i < blacklist.Count(); i++)
            {
                blacklist[i].tag = "SnapPoints";
            }
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (!blacklist.Contains(col.gameObject))
        {
            if (col.gameObject.tag == "SnapPoints")
            {
                blacklist.Add(col.gameObject);
                for (int i = 0; i < blacklist.Count(); i++)
                {
                    blacklist[i].tag = "SnapPointsBlacklist";
                }
            }
        }
    }

    public void GridSnap()
    {
        int i;
        int j;
        snapListSize = snapPoints.Count();
        pushableSize = pushable.Count();
        
        for (i = 0; i < (pushableSize); i++)
        {
            minDistance = Vector3.Distance(snapPoints[0].transform.position, pushable[i].transform.position);
            for (j = 1; j < (snapListSize); j++)
            {
                Vector3 snap = snapPoints[j].transform.position;
                distance = Vector3.Distance(snap, pushable[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestSnap = snap;
                }
            }
            pushable[i].transform.position = closestSnap;
        }
    }
}

