using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent _agent;

    int currentListSizeGrunt;
    int currentListSizeSniper;
    int currentListSizeTank;

    public GameObject allyUnit;
    public GameObject closestAvailablePoint;

    List<GameObject> allSnapPoints = new List<GameObject>();


    private void Update()
    {
        if (gameObject.GetComponent<GruntStats>() != null)
        {
            currentListSizeGrunt = gameObject.GetComponent<GruntStats>().gruntAvailableMoves.Count;
        }
        if (gameObject.GetComponent<SniperStats>() != null)
        {
            currentListSizeSniper = gameObject.GetComponent<SniperStats>().sniperAvailableMoves.Count;
        }
        if (gameObject.GetComponent<TankStats>() != null)
        {
            currentListSizeTank = gameObject.GetComponent<TankStats>().tankAvailableMoves.Count;
        }
        Debug.Log("update");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("sdogijn");
            GruntAI();
            SniperAI();
            TankAI();
        }
    }

    void GruntAI()
    {
        if (gameObject.GetComponent<GruntStats>() != null)
        {
            float minDistance = Vector3.Distance(gameObject.GetComponent<GruntStats>().gruntAvailableMoves[0].transform.position, allyUnit.transform.position);

            for (int i = 0; i < currentListSizeGrunt; i++)
            {
                float distanceFromAllyUnits = Vector3.Distance(gameObject.GetComponent<GruntStats>().gruntAvailableMoves[i].transform.position, allyUnit.transform.position);
                if (distanceFromAllyUnits < minDistance)
                {
                    minDistance = distanceFromAllyUnits;
                    closestAvailablePoint = gameObject.GetComponent<GruntStats>().gruntAvailableMoves[i];
                }
            }
            _agent.SetDestination(closestAvailablePoint.transform.position);
        }
    }

    void SniperAI()
    {
        if (gameObject.GetComponent<SniperStats>() != null)
        {
            float minDistance = Vector3.Distance(gameObject.GetComponent<SniperStats>().sniperAvailableMoves[0].transform.position, allyUnit.transform.position);

            for (int i = 0; i < currentListSizeSniper; i++)
            {
                float distanceFromAllyUnits = Vector3.Distance(gameObject.GetComponent<SniperStats>().sniperAvailableMoves[i].transform.position, allyUnit.transform.position);
                if (distanceFromAllyUnits < minDistance)
                {
                    minDistance = distanceFromAllyUnits;
                    closestAvailablePoint = gameObject.GetComponent<SniperStats>().sniperAvailableMoves[i];
                }
            }
            _agent.SetDestination(closestAvailablePoint.transform.position);
        }
    }

    void TankAI()
    {
        if (gameObject.GetComponent<TankStats>() != null)
        {
            float minDistance = Vector3.Distance(gameObject.GetComponent<TankStats>().tankAvailableMoves[0].transform.position, allyUnit.transform.position);

            for (int i = 0; i < currentListSizeTank; i++)
            {
                float distanceFromAllyUnits = Vector3.Distance(gameObject.GetComponent<TankStats>().tankAvailableMoves[i].transform.position, allyUnit.transform.position);
                if (distanceFromAllyUnits < minDistance)
                {
                    minDistance = distanceFromAllyUnits;
                    closestAvailablePoint = gameObject.GetComponent<TankStats>().tankAvailableMoves[i];
                }
            }
            _agent.SetDestination(closestAvailablePoint.transform.position);
        }
    }
}
