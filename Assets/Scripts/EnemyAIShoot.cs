
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIShoot : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask GroundCheck, PlayerCheck;

    public float health;
    

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {

        player = GameObject.Find("Target Practice").transform;
        agent = GetComponent<NavMeshAgent>();
    }



    private void Update()
    {
       
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, PlayerCheck);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, PlayerCheck);
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
   

    private void AttackPlayer()
    {
        
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);
            

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    
}
