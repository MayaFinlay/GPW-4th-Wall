
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIShoot : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask GroundCheck, PlayerCheck;

    public float health;

    bool hasAttacked;

    public float timeBetweenAttacks;
    public GameObject projectile;


    public float sightRange;
    public bool playerInSightRange;

    private void Start()
    {
        hasAttacked = false;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, PlayerCheck);
        if (playerInSightRange && gameObject.GetComponent<Enemy_Master>().Distance < 1.5 && hasAttacked == false)
        {
            AttackPlayer();
            hasAttacked = true;        
        }
    }

    private void AttackPlayer()
    {        
        transform.LookAt(player);
        
        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
        rb.AddForce(transform.up * 4f, ForceMode.Impulse);
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
