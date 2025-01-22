using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerData.Instance.SetHp(-1);
            SpawnManager.Instance.Despawn(this.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
