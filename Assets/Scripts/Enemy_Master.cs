using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Master : MonoBehaviour
{
    public GameObject Player;
    public float Distance;

    public bool Triggered;
    public NavMeshAgent _agent;

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        if (Distance <= 1000)
        {
            Triggered = true;
        }
        if (Distance > 20f)
        {
            Triggered = false;

        }
        if (Triggered)
        {
            _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);

        }
        if (!Triggered)
        {
            _agent.isStopped = true;
        }
    }
}