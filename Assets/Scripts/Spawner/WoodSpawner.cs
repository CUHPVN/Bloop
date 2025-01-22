using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    [SerializeField] private int woodCount=10;
    [SerializeField] private List<Transform> woodList = new();
    private void Awake()
    {
    }
    void Start()
    {
        SpawnWood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnWood()
    {
        woodCount = (3 / 2) * GameManager.Instance.level + 5 / 2;
        for (int i = -5; i < 5; i++)
        {
            for(int j = -5; j < 5; j++)
            {
                int ran = UnityEngine.Random.Range(0, (int)100 / woodCount);
                if (ran == 0)
                {
                    Transform obj = SpawnManager.Instance.Spawn("Wood", transform.position.x + i, transform.position.y + j, Quaternion.identity);
                    obj.GetComponent<Entity>().ResetComponent();
                    woodList.Add(obj);
                }
            }
            
        }
        if (woodList.Count == 0)
        {
            Transform obj = SpawnManager.Instance.Spawn("Wood", transform.position.x, transform.position.y, Quaternion.identity);
            obj.GetComponent<Entity>().ResetComponent();
            woodList.Add(obj);
        }
    }
    public void DespawnWood()
    {
        foreach(Transform t in woodList)
        {
            SpawnManager.Instance.Despawn(t);
        }
        woodList.Clear();
    }
}
