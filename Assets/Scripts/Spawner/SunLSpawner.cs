using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLSpawner : MonoBehaviour
{
    [SerializeField] private int sunlCount=10;
    [SerializeField] private List<Transform> sunlList = new();
    private void Awake()
    {
    }
    void Start()
    {
        SpawnSunL();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnSunL()
    {
        sunlCount = (5 / 4) * GameManager.Instance.level + 3 / 4;
        for (int i = -5; i < 5; i++)
        {
            for(int j = -5; j < 5; j++)
            {
                int ran = UnityEngine.Random.Range(0, (int)100 / sunlCount);
                if (ran == 0)
                {
                    Transform obj = SpawnManager.Instance.Spawn("SunL", transform.position.x + i, transform.position.y + j, Quaternion.identity);
                    obj.GetComponent<Entity>().ResetComponent();
                    sunlList.Add(obj);
                }

            }

        }
        if (sunlList.Count == 0)
        {
            Transform obj = SpawnManager.Instance.Spawn("SunL", transform.position.x, transform.position.y, Quaternion.identity);
            obj.GetComponent<Entity>().ResetComponent();
            sunlList.Add(obj);
        }
    }
    public void DespawnSunL()
    {
        foreach(Transform t in sunlList)
        {
            SpawnManager.Instance.Despawn(t);
        }
        sunlList.Clear();
    }
}
