using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBlacklist : MonoBehaviour
{


    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "SnapPoints") 
        { 

        }
    }
}
