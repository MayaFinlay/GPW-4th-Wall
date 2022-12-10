using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntStats : MonoBehaviour
{
    public List<GameObject> gruntAvailableMoves = new List<GameObject>();
    public List<GameObject> fireSquares = new List<GameObject>();

    public Collider move;
    public Collider shoot;

    public void OnTriggerEnter()
    {
        if (!gruntAvailableMoves.Contains(move.gameObject))
        {
            if (move.gameObject.tag == "SnapPoints")
            {
                gruntAvailableMoves.Add(move.gameObject);
            }
        }
        if (!fireSquares.Contains(shoot.gameObject))
        {
            if (shoot.gameObject.tag == "SnapPoints")
            {
                fireSquares.Add(shoot.gameObject);
            }
        }
    }

    public void OnTriggerExit()
    {
        if (gruntAvailableMoves.Contains(move.gameObject))
        {
            gruntAvailableMoves.Remove(move.gameObject);
        }
        if (!fireSquares.Contains(shoot.gameObject))
        {
            if (shoot.gameObject.tag == "SnapPoints")
            {
                fireSquares.Add(shoot.gameObject);
            }
        }
    }
}
