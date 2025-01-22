using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour
{
    [SerializeField] private PetControl petControl;
    [SerializeField] private LayerMask interactLayer;
    void Start()
    {
        petControl = GameObject.Find("Player").GetComponent<PetControl>();
        
    }

    void Update()
    {
        if (InputManager.Instance.lClick)
        {
            if(LookGameObject(out RaycastHit2D hit))
            {
                PressLeftDown(hit.collider.gameObject);
            }
        }
        if (InputManager.Instance.rClick)
        {
            if (LookGameObject(out RaycastHit2D hit))
            {
                PressRightDown(hit.collider.gameObject);
            }
        }
    }
    private bool LookGameObject(out RaycastHit2D hit)
    {
        var ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition),Mathf.Infinity,interactLayer);

        if (ray)
        {
            hit = ray;
            return true;
        }
        else
        {
            hit = default;
            return false;
        }
    }
    private void PressLeftDown(GameObject target)
    {
        if (target.TryGetComponent(out Transform trans))
        {
            if(trans.tag == "Entity"&&!trans.GetComponent<Entity>().GetDeath())
            petControl.SendPet(trans);
        }
    }
    private void PressRightDown(GameObject target)
    {
        if (target.TryGetComponent(out Transform trans))
        {
            if (trans.tag == "Entity")
            petControl.GetPet(trans);
        }
    }
}
