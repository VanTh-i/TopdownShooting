using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : ThaiBehaviour
{
    protected Transform player;
    protected float maxDistance = 20f;
    protected override void LoadComponents()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    protected IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            float randomPosX = player.position.x + Random.Range(-maxDistance, maxDistance);
            float randomPosY = player.position.y + Random.Range(-maxDistance, maxDistance);
            Vector3 spawnPos = new Vector3(randomPosX, randomPosY, player.position.z);
            Quaternion rot = transform.rotation;

            Transform enemy = EnemySpawn.Instance.Spawn(spawnPos, rot);
            enemy.gameObject.SetActive(true);

            yield return new WaitForSeconds(2f);
        }

    }
}
