    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed=25f;
    private Vector3 offset= new Vector3(0, 0, -10f);
    private Vector3 velocity = Vector3.zero;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position+offset;
    
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity,speed/100);
    }
}
