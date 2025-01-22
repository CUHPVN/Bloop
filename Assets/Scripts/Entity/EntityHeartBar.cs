using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EntityHeartBar : MonoBehaviour
{
    [SerializeField] protected Canvas canvas;
    [SerializeField] protected Slider hpBar;
    [SerializeField] protected Entity entity;

    void Start()
    {
        LoadComponent();
    }

    // Update is called once per frame
    private void Update()
    {
        float value = entity.GetHp() / entity.GetMaxHp();
        if (value >= 1) canvas.gameObject.SetActive(false);
        else
        {
            canvas.gameObject.SetActive(true);
        }
        hpBar.value = value;
        
    }
    protected void LoadComponent()
    {
        canvas = GetComponentInChildren<Canvas>();
        hpBar = canvas.GetComponentInChildren<Slider>();
        entity = GetComponent<Entity>();
    }
}
