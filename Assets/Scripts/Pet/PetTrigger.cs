using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTrigger : MonoBehaviour
{
    [SerializeField] private Pet pet;
    private void Start()
    {
        pet = transform.parent.GetComponent<Pet>();
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Entity")
        {
            if (pet.GetCanAttack()&&collision.TryGetComponent<Entity>(out Entity entity))
            {
                entity.SetDamage(pet.GetAttackDamage());
                pet.Attack();
            }
        }
    }*/
    
    
}
