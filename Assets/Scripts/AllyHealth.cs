using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    public float maxHealth;
    public int currentHealth;
    public GameObject unit;

    [SerializeField] private Healthbar healthbar;

    private void Start()
    {
        healthbar.HealthbarFunction(maxHealth, currentHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(unit);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet" && col.attachedRigidbody.gameObject)
        {
            healthbar.HealthbarFunction(maxHealth, currentHealth);
            currentHealth -= 30;
        }
    }
}
