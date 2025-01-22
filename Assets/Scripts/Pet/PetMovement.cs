using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PetMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    public Vector3 velocity,playerMove;
    [SerializeField]private float speed=5f;
    private float tempSpeed = 5f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        MoveToPLayer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void SetSpeedInvoke(float speed,float time)
    {
        tempSpeed = speed;
        Invoke(nameof(InvokeSpeed), time);

    }
    public void InvokeSpeed()
    {
        speed = tempSpeed;
    }
    public void SendTrigger(Collider2D triggerObj)
    {
        //NonStick(triggerObj.transform.position);
    }
    
    private void MoveToPLayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, playerMove, ref velocity, 1/speed); ;
    }
}
