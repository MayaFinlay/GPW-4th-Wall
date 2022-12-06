using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Master : MonoBehaviour
{
    public GameObject gridPoint;
    public bool moving;
    public NavMeshAgent _agent;
    public float Distance;

    public List<GameObject> snapPoints = new List<GameObject>();

    // Update is called once per frame
    void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("SnapPoints"))
        {
            snapPoints.Add(fooObj);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gridPoint = snapPoints[Random.Range(0, 80)];
            gameObject.GetComponent<EnemyAIShoot>().hasAttacked = false;


            Move();
        }
        Distance = Vector3.Distance(gridPoint.transform.position, this.transform.position);
    }

    private void Move()
    {
        
        if (Distance > 0)
        {
            _agent.SetDestination(gridPoint.transform.position);
        }
    }

}