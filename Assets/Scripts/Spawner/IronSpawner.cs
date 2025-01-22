using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSpawner : MonoBehaviour
{
    [SerializeField] private int ironCount=10;
    [SerializeField] private List<Transform> ironList = new();
    private void Awake()
    {
    }
    void Start()
    {
        SpawnIron();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnIron()
    {
        ironCount = (7 / 4) * GameManager.Instance.level + 13 / 4;
        for (int i = -5; i < 5; i++)
        {
            for(int j = -5; j < 5; j++)
            {
                int ran = UnityEngine.Random.Range(0, (int)100 / ironCount);
                if (ran == 0)
                {
                    Transform obj = SpawnManager.Instance.Spawn("Iron", transform.position.x + i, transform.position.y + j, Quaternion.identity);
                    obj.GetComponent<Entity>().ResetComponent();
                    ironList.Add(obj);
                }

            }

        }
        if(ironList.Count == 0)
        {
            Transform obj = SpawnManager.Instance.Spawn("Iron", transform.position.x, transform.position.y, Quaternion.identity);
            obj.GetComponent<Entity>().ResetComponent();
            ironList.Add(obj);
        }
    }
    public void DespawnIron()
    {
        foreach(Transform t in ironList)
        {
            SpawnManager.Instance.Despawn(t);
        }
        ironList.Clear();
    }
}
