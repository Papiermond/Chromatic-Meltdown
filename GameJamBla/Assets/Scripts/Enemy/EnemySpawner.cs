using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject SpawnThis;
    private Transform Player;
    private float timer = 0;
    public float spawnTimeDelay = 1f, spawnDistance = 5f;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTimeDelay)
        {
            if (Vector2.Distance(transform.position,ReferenceManager.Instance.Player.transform.position) < spawnDistance)
            {
                Instantiate(SpawnThis, transform.position,transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
