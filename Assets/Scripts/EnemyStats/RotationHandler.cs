using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RotationHandler : MonoBehaviour
{
    public GameObject enemy;

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = enemy.transform.position;
    }
}
