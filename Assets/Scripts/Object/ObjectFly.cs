using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFly : MonoBehaviour
{
    [SerializeField] protected float movespeed = 10f;
    [SerializeField] protected Vector3 direction = Vector3.up;

    private void FixedUpdate()
    {
        transform.Translate(direction * movespeed * Time.fixedDeltaTime);
    }
}
