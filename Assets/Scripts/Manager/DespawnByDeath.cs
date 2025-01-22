using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDeath : Despawn
{
    private float hp=0;
    private bool isDeath=false;
    void GetHp()
    {
        if(TryGetComponent<Entity>(out Entity entity))
        {
            hp = entity.GetHp();
        }
    }
    void Update()
    {
        GetHp();
        if (hp <= 0&&!isDeath)
        {
            isDeath = true;
            if (transform.name == "Fork" || transform.name == "Nail" || transform.name == "Cactus")
            EnemySpawn.Instance.spawnCount++;
            Invoke(nameof(DespawnObj), 0.25f);

        }
    }
    protected override void DespawnObj()
    {
        base.DespawnObj();
        isDeath = false;
    }
}
