using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    private void Start()
    {
        SpawnEnemy();
    }

    protected virtual void SpawnEnemy()
    {
        float randomPosX = Random.Range(-10, 10);
        float randomPosY = Random.Range(-10, 10);
        Vector3 spawnPos = new Vector3(randomPosX, randomPosY, 0);
        Quaternion rot = transform.rotation;
        Transform enemy = EnemySpawn.Instance.Spawn(spawnPos, rot, 0);
        enemy.gameObject.SetActive(true);

        Invoke(nameof(SpawnEnemy), 1f);
    }
}
