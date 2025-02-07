using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeparation : MonoBehaviour
{
    public float minDistance = 1.5f;
    public float repelForce = 10f;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, minDistance);

        foreach (Collider other in colliders)
        {
            if (other.gameObject != this.gameObject&&other.tag =="Entity")
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 repelDirection = other.transform.position - transform.position;
                    rb.AddForce(repelDirection.normalized * repelForce, ForceMode.Impulse);
                }
            }
        }
    }

}
