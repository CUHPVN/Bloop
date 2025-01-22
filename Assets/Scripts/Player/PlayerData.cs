using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance;
    public static PlayerData Instance { get { return instance; } }
    [SerializeField] protected float shakeDuration = 0.1f, shakeMagnitude = 0.05f;
    [SerializeField] private float hp=1, maxHp = 5;
    [SerializeField] private int sunl   , iron,wood;
    [SerializeField] private bool isDeath=false,isImmortal= false;
    private void Awake()
    {
        instance = this;
        sunl = 0; iron = 0; wood = 0;

    }
    void Start()
    {
    }

    void Update()
    {
        if (isImmortal)
        {
            hp = maxHp;
        }
        if(hp <= 0)
        {

            hp = 0;
            isDeath = true;
        }
    }
    public void SetDeath(bool value)
    {
        isDeath = value;
    }
    public bool GetDeath()
    {
        return isDeath;
    }
    public void SetHp(float value)
    {
        hp += value;
        StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(shakeDuration,shakeMagnitude));
    }
    public void Heal(float value)
    {
        hp += value;
    }
    public void SetMaxHp(float value)
    {
        maxHp += value;
    }
    public void SetSunL(int value)
    {
        sunl += value;
    }
    public void SetIron(int value)
    {
        iron += value;
    }
    public void SetWood(int value)
    {
        wood += value;
    }
    public float GetHp()
    {
        return hp;
    }
    public float GetMaxHp()
    {
        return maxHp;
    }
    public int GetSunL()
    {
        return sunl;
    }
    public int GetIron()
    {
        return iron;
    }
    public int GetWood()
    {
        return wood;
    }
}
