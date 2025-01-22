using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTrigger : MonoBehaviour
{
    [SerializeField] private Entity entity;
    private void Start()
    {
        entity = transform.parent.GetComponent<Entity>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&transform.parent.name=="Nail")
        {
            PlayerData.Instance.SetHp(-1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
        }
    }

}
