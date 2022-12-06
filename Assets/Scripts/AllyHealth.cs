using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    public int health = 100;


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health -= 50;
        }
    }

}
