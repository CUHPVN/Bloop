using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f, dashSpeed = 7f, dashAmount = 7f, dashDelay = 1f, tempMinimum = 7 * 3 / 7, tempSpeedDrop = 7 * 2 / 7;
    private float x, y;
    [SerializeField] private bool canMove = true,canDash= true;
    [SerializeField] private LayerMask dashLayer;
    private Rigidbody2D rb;
    private Vector2 axis;
    private Vector3 target,velocity = Vector3.zero;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Dash();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
        else
        {
            rb.velocity = (target - transform.position) * dashSpeed;
        }
    }
    private void Move()
    {
        x = InputManager.Instance.x; y = InputManager.Instance.y;
        axis = new Vector2(x, y);
        if (axis.magnitude > 1)
        {
            axis.Normalize();
        }   
        rb.velocity = axis * speed;

    }
    private void Dash()
    {
        if (InputManager.Instance.lShift & canDash)
        {
            //canMove = false;
            
            Vector3 Pos = InputManager.Instance.mousePos - rb.position;
            //Pos.Normalize();
            Vector3 dashPos;
            if (Pos.magnitude >= dashAmount)
            {
                Pos.Normalize();
                dashPos = transform.position + Pos * dashAmount;
            }
            else dashPos = transform.position + Pos;
            
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Pos, Vector3.Distance(dashPos, transform.position), dashLayer);
            if (ray.collider != null)
            {
                dashPos = ray.point;
                

            }
            target = dashPos;
            canDash = false;
            canMove = false;
            dashSpeed = 7f+7/Vector3.Distance(dashPos, transform.position);
            tempSpeedDrop = dashSpeed * 2 / 7;
            tempMinimum = dashSpeed * 3 / 7;
            //rb.MovePosition(dashPos);
            //InputManager.Instance.x = dashPos.x;
            //InputManager.Instance.y = dashPos.y;
            Invoke(nameof(DashDelay), dashDelay);
        }
        if(!canMove)
        {
            float rollSpeedDropMultiplier = tempSpeedDrop;
            dashSpeed -= dashSpeed * rollSpeedDropMultiplier * Time.deltaTime;
            float rollSpeedMinimum = tempMinimum;
            if(dashSpeed < rollSpeedMinimum)
            {
                canMove = true;
            }
        }
    }
    private void DashDelay()
    {
        canDash = true;
    }
}
