using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntStats : MonoBehaviour
{
    public List<GameObject> gruntAvailableMoves = new List<GameObject>();
    public List<GameObject> fireSquares = new List<GameObject>();

    public void OnTriggerEnter(Collider col)
    {
        if (!gruntAvailableMoves.Contains(col.gameObject))
        {
            if (col.gameObject.tag == "SnapPoints")
            {
                gruntAvailableMoves.Add(col.gameObject);
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (gruntAvailableMoves.Contains(col.gameObject))
        {
            gruntAvailableMoves.Remove(col.gameObject);
        }
    }
}
