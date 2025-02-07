using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minDistance = 1f; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.transform.name == "Fork") MoveToPlayer();
        if (rb.transform.name == "Cactus") MoveToDistance(4);
        if (rb.transform.name == "Nail") MoveToDistance(4);
        if(rb.transform.name=="Fork"|| rb.transform.name == "Nail"|| rb.transform.name == "Cactus") AvoidOverlap();
    }

    void MoveToPlayer()
    {
        if (Vector3.Distance(PlayerData.Instance.transform.position, transform.position) <= 0.5f)
        {
            rb.velocity = Vector3.zero;

        }
        else
        {
            Vector3 dir = PlayerData.Instance.transform.position - transform.position;
            rb.velocity = dir.normalized * speed;

        }
    }

    void MoveToDistance(float dis)
    {
        if (Vector3.Distance(PlayerData.Instance.transform.position, transform.position) <= dis)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            Vector3 dir = PlayerData.Instance.transform.position - transform.position;
            rb.velocity = dir.normalized * speed;
        }
    }

    void AvoidOverlap()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, minDistance);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != this.gameObject&&collider.tag=="Entity"&&collider.name!="Trigger") 
            {
                Vector3 directionAway = transform.position - collider.transform.position;
                directionAway.z = 0;
                rb.AddForce(directionAway.normalized * speed,ForceMode2D.Force);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}
