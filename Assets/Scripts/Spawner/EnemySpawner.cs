using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyCount=10;
    [SerializeField] private List<Transform> enemyList = new();
    private void Awake()
    {
    }
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        for(int i = -5; i < 5; i++)
        {
            for(int j = -5; j < 5; j++)
            {
                int ran = UnityEngine.Random.Range(0, (int)100 / enemyCount);
                if(ran == 0) enemyList.Add(SpawnManager.Instance.Spawn("Cactus", transform.position.x+i,transform.position.y+j, Quaternion.identity));
            }
            
        }
    }
    public void DespawnEnemy()
    {
        foreach(Transform t in enemyList)
        {
            SpawnManager.Instance.Despawn(t);
        }
        enemyList.Clear();
    }
}
