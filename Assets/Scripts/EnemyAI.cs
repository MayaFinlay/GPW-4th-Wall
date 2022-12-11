using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent _agent;

    float distanceFromAllyUnits;
    float minDistance;

    public GameObject allyUnit;
    public GameObject closestAvailablePoint;

    List<GameObject> allSnapPoints = new List<GameObject>();

    //List<GameObject> gruntAvailableMoves = new List<GameObject>();
    //List<GameObject> gruntFirePoints = new List<GameObject>();

    //List<GameObject> sniperAvailableMoves = new List<GameObject>();
    //List<GameObject> sniperFirePoints = new List<GameObject>();

    //List<GameObject> tankAvailableMoves = new List<GameObject>();
    //List<GameObject> tankFirePoints = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("SnapPoints"))
        {
            allSnapPoints.Add(fooObj);
        }
        _agent.SetDestination(allSnapPoints[31].transform.position);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GruntAI();
        }       
    }

    void GruntAI()
    {
        allSnapPoints.Clear();
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("SnapPoints"))
        {
            allSnapPoints.Add(fooObj);
        }
        allSnapPoints.Sort((x, y) => Vector3.Distance(transform.position, x.transform.position).CompareTo(Vector3.Distance(transform.position, y.transform.position)));
        minDistance = Vector3.Distance(allSnapPoints[0].transform.position, allyUnit.transform.position);

        for (int i = 0; i < 9; i++)
        {            
            distanceFromAllyUnits = Vector3.Distance(allSnapPoints[i].transform.position, allyUnit.transform.position);
            if (distanceFromAllyUnits < minDistance)
            {
                minDistance = distanceFromAllyUnits;
                closestAvailablePoint = allSnapPoints[i];
            }
        }
        _agent.SetDestination(closestAvailablePoint.transform.position);
    }

    void SniperAI()
    {

    }

    void TankAI()
    {

    }
}
