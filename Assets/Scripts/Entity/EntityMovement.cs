using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(rb.transform.name == "Fork") MoveToPlayer();
        if(rb.transform.name == "Cactus") MoveToDistance(4);
        if (rb.transform.name == "Nail") MoveToDistance(4);
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
}
