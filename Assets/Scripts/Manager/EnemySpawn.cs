using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private List<Transform> points = new List<Transform>();
    private int enemyCount;
    public int spawnCount;
    private bool endWave=true;

    private static EnemySpawn instance;
    public static EnemySpawn Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        LoadSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCount == LevelManager.Instance.GetCount(GameManager.Instance.level))
        {
            GameManager.Instance.EndWave();
            endWave = true;
            enemyCount = 0;
            spawnCount = 0;
            SoundManager.Instance.PlayMusicByIndex(0);

        }
        if (GameManager.Instance.GetChill() == false&&endWave)
        {
            endWave = false;

            SoundManager.Instance.PlayMusicByIndex(1);
            StartWave(GameManager.Instance.level);
        }
    }
    private void LoadSpawnPos()
    {
        foreach(Transform t in transform)
        {
            points.Add(t);
        }
    }
    private void StartWave(int level)
    {
        float y = -0.375f * level + 2.375f;
        Invoke(nameof(Spawn), y);
        
    }
    private void Spawn()
    {
        enemyCount++;

        int ran = UnityEngine.Random.Range(0, points.Count);
        Transform transform = SpawnManager.Instance.Spawn(LevelManager.Instance.GetName(GameManager.Instance.level, enemyCount-1), points[ran].position.x, points[ran].position.y,Quaternion.identity);
        transform.GetComponent<Entity>().ResetComponent();
        if(enemyCount < LevelManager.Instance.GetCount(GameManager.Instance.level))
        {
            float y = -0.375f * GameManager.Instance.level + 2.375f;

            Invoke(nameof(Spawn), y);
        }
        
    }
}
