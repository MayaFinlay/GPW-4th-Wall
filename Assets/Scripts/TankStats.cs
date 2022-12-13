using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStats : MonoBehaviour
{
    public List<GameObject> tankAvailableMoves = new List<GameObject>();

    public void OnTriggerEnter(Collider col)
    {
        if (!tankAvailableMoves.Contains(col.gameObject))
        {
            if (col.gameObject.tag == "SnapPoints" || col.gameObject.tag == "SnapPointsBlackList")
            {
                tankAvailableMoves.Add(col.gameObject);
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (tankAvailableMoves.Contains(col.gameObject))
        {
            tankAvailableMoves.Remove(col.gameObject);
        }
    }
}
