using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ally" || col.gameObject.tag == "Pushable" || col.gameObject.tag == "Pushable")
        {
            Destroy(this);
        }
    }
}
