using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CraftPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text item1,item2;
    private void Awake()
    {
        CheckCraft();
    }
    void Start()
    {
        CheckCraft();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCraft();
    }
    public void CheckCraft()
    {
        if (transform.name != "Heart")
        {
            if (UIManager.Instance.GetCompareWood(item1))
            {
                item1.color = Color.green;
            }
            else
            {
                item1.color = Color.red;
            }
            if (UIManager.Instance.GetCompareIron(item2))
            {
                item2.color = Color.green;
            }
            else
            {
                item2.color = Color.red;
            }
        }
        else
        {
            if (UIManager.Instance.GetCompareSunL(item1))
            {
                item1.color = Color.green;
            }
            else
            {
                item1.color = Color.red;
            }
        }
    }
    public void Craft()
    {
        if (transform.name != "Heart")
        {
            if (UIManager.Instance.GetCompareWood(item1) && UIManager.Instance.GetCompareIron(item2))
            {
                PlayerData.Instance.SetWood(-Convert.ToInt32(item1.text));
                PlayerData.Instance.SetIron(-Convert.ToInt32(item2.text));
                PlayerData.Instance.GetComponent<PetControl>().CreatePet(transform.name);
            }

            
        }
        else
        {
            if (UIManager.Instance.GetCompareSunL(item1))
            {
                if(PlayerData.Instance.GetHp() < PlayerData.Instance.GetMaxHp())
                {
                    PlayerData.Instance.SetSunL(-Convert.ToInt32(item1.text));
                    PlayerData.Instance.Heal(1);
                }
                
            }
        }
    }
}
