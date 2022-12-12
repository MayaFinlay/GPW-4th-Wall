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
            if (col.gameObject.tag == "SnapPoints")
            {
                tankAvailableMoves.Add(col.gameObject);
                Debug.Log("Added " + gameObject.name);
                Debug.Log("GameObjects in list: " + tankAvailableMoves.Count);
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (tankAvailableMoves.Contains(col.gameObject))
        {
            tankAvailableMoves.Remove(col.gameObject);
            Debug.Log("Removed " + gameObject.name);
            Debug.Log("GameObjects in list: " + tankAvailableMoves.Count);
        }
    }
}
