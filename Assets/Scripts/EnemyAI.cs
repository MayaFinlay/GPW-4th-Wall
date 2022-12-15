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

    public Animator enemyAnimator;


    //bool fireState;

    public GameObject grunt;
    public GameObject sniper;
    public GameObject tank;
    public GameObject projectileGrunt;
    public GameObject projectileSniper;
    public GameObject projectileTank;

    public List<GameObject> allyUnits = new List<GameObject>();
    public GameObject closestAvailablePoint;

    public List<GameObject> gridBlacklist = new List<GameObject>();
    List<GameObject> allSnapPoints = new List<GameObject>();

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Ally"))
        {
            allyUnits.Add(fooObj);
        }
        //fireState = false;
    }

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GruntAI();
            SniperAI();
            TankAI();
        }
        if (_agent.velocity.magnitude < 0.1)
        {
            enemyAnimator.SetBool("Move", false);
        }
        else
        {
            enemyAnimator.SetBool("Move", true);
        }
    }

    void GruntAI()
    {
        if (gameObject.GetComponent<GruntStats>() != null)
        {
            int randomUnit = Random.Range(0, 3);
            float minDistance = Vector3.Distance(gameObject.GetComponent<GruntStats>().gruntAvailableMoves[0].transform.position, allyUnits[randomUnit].transform.position);
            float currentDistance = Vector3.Distance(grunt.transform.position, allyUnits[randomUnit].transform.position);
            if (currentDistance > 8)
            {
                for (int i = 0; i < currentListSizeGrunt; i++)
                {
                    float distanceFromAllyUnits = Vector3.Distance(gameObject.GetComponent<GruntStats>().gruntAvailableMoves[i].transform.position, allyUnits[randomUnit].transform.position);
                    if (distanceFromAllyUnits < minDistance && gameObject.GetComponent<GruntStats>().gruntAvailableMoves[i].tag == "SnapPoints")
                    {
                        minDistance = distanceFromAllyUnits;
                        closestAvailablePoint = gameObject.GetComponent<GruntStats>().gruntAvailableMoves[i];
                    }
                }         

                _agent.SetDestination(closestAvailablePoint.transform.position);

                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Move", true); // take out when the character can stop

                /* Animation cannot stop - tried the following methods
                if (_agent.transform.position == closestAvailablePoint.transform.position)
                if (_agent.pathStatus==NavMeshPathStatus.completed)
                if (!_agent.pathPending)
                if (_agent.distanceRemaining < _agent.stoppingDistance)
                {
                    enemyAnimator.SetBool("Move", false);
                }
                else
                {
                    enemyAnimator.SetBool("Move", true);
                }
                */

            }
            else if (currentDistance < 8)
            {
                transform.LookAt(allyUnits[randomUnit].transform.position);
                var rayOrigin = this.transform.position;
                var rayDirection = allyUnits[randomUnit].transform.position;
                //RaycastHit hitInfo;
                //if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
                //{
                    //if (hitInfo.transform.tag != "Pushable")
                    //{
                        Rigidbody rb = Instantiate(projectileSniper, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                        rb.AddForce(transform.forward * 40f, ForceMode.Impulse);

                enemyAnimator.SetBool("Attack", true);
                enemyAnimator.SetBool("Move", false);

            }
            else
            {
                enemyAnimator.SetBool("Move", false);
                enemyAnimator.SetBool("Attack", false);
            }
        }
    }
    
    void SniperAI()
    {
        if (gameObject.GetComponent<SniperStats>() != null)
        {
            int randomUnit = Random.Range(0, 3);
            float minDistance = Vector3.Distance(gameObject.GetComponent<SniperStats>().sniperAvailableMoves[0].transform.position, allyUnits[randomUnit].transform.position);
            float currentDistance = Vector3.Distance(sniper.transform.position, allyUnits[randomUnit].transform.position);
            if (currentDistance > 15)
            {
                for (int i = 0; i < currentListSizeSniper; i++)
                {
                    float distanceFromAllyUnits = Vector3.Distance(gameObject.GetComponent<SniperStats>().sniperAvailableMoves[i].transform.position, allyUnits[randomUnit].transform.position);
                    if (distanceFromAllyUnits < minDistance && gameObject.GetComponent<SniperStats>().sniperAvailableMoves[i].tag == "SnapPoints")
                    {
                        minDistance = distanceFromAllyUnits;
                        closestAvailablePoint = gameObject.GetComponent<SniperStats>().sniperAvailableMoves[i];
                    }
                }
                _agent.SetDestination(closestAvailablePoint.transform.position);

                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Move", true); // take out when the character can stop

                /* Animation cannot stop - tried the following methods
                if (_agent.transform.position == closestAvailablePoint.transform.position)
                if (_agent.pathStatus==NavMeshPathStatus.completed)
                if (!_agent.pathPending)
                if (_agent.distanceRemaining < _agent.stoppingDistance)
                {
                    enemyAnimator.SetBool("Move", false);
                }
                else
                {
                    enemyAnimator.SetBool("Move", true);
                }
                */
            }
            else if (currentDistance < 15)
            {
                transform.LookAt(allyUnits[randomUnit].transform.position);
                var rayOrigin = this.transform.position;
                var rayDirection = allyUnits[randomUnit].transform.position;
                //RaycastHit hitInfo;
                //if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
                //{
                    //if (hitInfo.transform.tag != "Pushable")
                    //{
                        Rigidbody rb = Instantiate(projectileSniper, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                        rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
                //}
                //}

                enemyAnimator.SetBool("Attack", true);
                enemyAnimator.SetBool("Move", false);

            }
            else
            {
                enemyAnimator.SetBool("Move", false);
                enemyAnimator.SetBool("Attack", false);
            }
        }
    }

    void TankAI()
    {
        if (gameObject.GetComponent<TankStats>() != null)
        {
            int randomUnit = Random.Range(0, 3);
            float minDistance = Vector3.Distance(gameObject.GetComponent<TankStats>().tankAvailableMoves[0].transform.position, allyUnits[randomUnit].transform.position);
            float currentDistance = Vector3.Distance(tank.transform.position, allyUnits[randomUnit].transform.position);
            if (currentDistance > 5)
            {
                for (int i = 0; i < currentListSizeTank; i++)
                {
                    float distanceFromAllyUnits = Vector3.Distance(gameObject.GetComponent<TankStats>().tankAvailableMoves[i].transform.position, allyUnits[randomUnit].transform.position);
                    if (distanceFromAllyUnits < minDistance && gameObject.GetComponent<TankStats>().tankAvailableMoves[i].tag == "SnapPoints")
                    {
                        minDistance = distanceFromAllyUnits;
                        closestAvailablePoint = gameObject.GetComponent<TankStats>().tankAvailableMoves[i];
                    }
                }
                _agent.SetDestination(closestAvailablePoint.transform.position);

                enemyAnimator.SetBool("Attack", false);
                enemyAnimator.SetBool("Move", true); // take out when the character can stop

                /* Animation cannot stop - tried the following methods
                if (_agent.transform.position == closestAvailablePoint.transform.position)
                if (_agent.pathStatus==NavMeshPathStatus.completed)
                if (!_agent.pathPending)
                if (_agent.distanceRemaining < _agent.stoppingDistance)
                {
                    enemyAnimator.SetBool("Move", false);
                }
                else
                {
                    enemyAnimator.SetBool("Move", true);
                }
                */
            }
            else if (currentDistance < 5)
            {
                transform.LookAt(allyUnits[randomUnit].transform.position);
                var rayOrigin = this.transform.position;
                var rayDirection = allyUnits[randomUnit].transform.position;
                //RaycastHit hitInfo;
                Rigidbody rb = Instantiate(projectileSniper, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 40f, ForceMode.Impulse);

                enemyAnimator.SetBool("Attack", true);
                enemyAnimator.SetBool("Move", false);

            }
            else
            {
                enemyAnimator.SetBool("Move", false);
                enemyAnimator.SetBool("Shoot", false);
            }
        }            
    }
}
