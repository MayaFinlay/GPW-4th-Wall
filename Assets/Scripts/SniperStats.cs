using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperStats : MonoBehaviour
{
    public List<GameObject> sniperAvailableMoves = new List<GameObject>();

    public void OnTriggerEnter(Collider col)
    {
        if (!sniperAvailableMoves.Contains(col.gameObject))
        {
            if (col.gameObject.tag == "SnapPoints")
            {
                sniperAvailableMoves.Add(col.gameObject);
                Debug.Log("Added " + gameObject.name);
                Debug.Log("GameObjects in list: " + sniperAvailableMoves.Count);
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (sniperAvailableMoves.Contains(col.gameObject))
        {
            sniperAvailableMoves.Remove(col.gameObject);
            Debug.Log("Removed " + gameObject.name);
            Debug.Log("GameObjects in list: " + sniperAvailableMoves.Count);
        }
    }
}
