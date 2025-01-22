using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private float attackDamage=2f,attackSpeed=3f;
    private bool canAttack=true;
    [SerializeField] private Transform targetTransform;
    void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateList();
        DamageDeal();
        TurnToPlayer();
    }
    private void TurnToPlayer()
    {
        if(targetTransform.gameObject.activeSelf == false)
        {
            targetTransform = GameObject.Find("Player").transform;
        }
    }
    private void UpdateList()
    {
        if(targetTransform.tag =="Player")
        {
            GetComponent<PetMovement>().SetSpeed(5f);
            if(targetTransform.GetComponent<PetControl>().CheckPet(transform))
            targetTransform.GetComponent<PetControl>().AddPet(transform);
        }
        else
        {
            //GetComponent<PetMovement>().SetSpeedInvoke(50f,0.25f);
        }

    }
    private void DamageDeal()
    {
        if (targetTransform.tag == "Entity")
        {
            if (GetCanAttack() && targetTransform.TryGetComponent<Entity>(out Entity entity))
            {
                if (entity.GetHp() <= 0) return;
                SoundManager.Instance.PlayHitSound();
                entity.SetDamage(GetAttackDamage());
                Attack();
            }
        }
    }
    public void SetTarget(Transform trans)
    {
        targetTransform = trans;
    }
    public float GetAttackDamage()
    {
        return attackDamage;
    }
    public bool GetCanAttack()
    {
        return canAttack;
    }
    public void Attack()
    {
        canAttack = false;
        Invoke("CountDown",attackSpeed);
    }
    private void CountDown()
    {
        canAttack= true;
    }
}
