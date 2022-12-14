using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPush : MonoBehaviour
{
    [SerializeField] float forceMagnitude;
    [SerializeField] bool positive;
    Vector3 forceDirection;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        Vector3 forceDirection = hit.gameObject.transform.position - transform.position;

        if (rigidbody != null)
        {            
            forceDirection.y = 0;
            forceDirection.Normalize();

            if (Mathf.Abs(forceDirection.x) > Mathf.Abs(forceDirection.z))
            {
                forceDirection.z = 0;
                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
            if (Mathf.Abs(forceDirection.z) > Mathf.Abs(forceDirection.x))
            {
                forceDirection.x = 0;
                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
        }
    }
}
