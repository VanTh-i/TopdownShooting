using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyType> enemyTypes;
        public int waveQuantity; // so luong ke dich co trong luot
        public int spawnInterval; // gian cach spawn
        public int spawnCount; // so luong ke dich da spawn
    }

    [System.Serializable]
    public class EnemyType
    {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefab;
    }

    public List<Wave> waves;
    public int currWaveCount;
    protected Transform player;

    [Header("Wave Interval")]
    public float waveInterval; // gian cach moi wave
    private float spawnTimer;
    public int maxEnemiesAllowed;
    public int enemiesAlive;
    public bool maxEnemiesReached = false;

    [Header("Spawn Position")]
    public List<Transform> spawnPosition;



    private void Awake()
    {
        player = FindPlayer.GetPlayer();
        if (player == null)
        {
            Debug.LogError("Can not find player");
        }
    }

    private void Start()
    {
        CalculateWaveQuantity();
    }

    private void Update()
    {
        if (currWaveCount < waves.Count && waves[currWaveCount].spawnCount == 0)
        {
            StartCoroutine(BeginNextWave());
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= waves[currWaveCount].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    private void CalculateWaveQuantity()
    {
        int currWaveQuantity = 0;
        foreach (var enemyType in waves[currWaveCount].enemyTypes)
        {
            currWaveQuantity += enemyType.enemyCount;
        }

        waves[currWaveCount].waveQuantity = currWaveQuantity;
    }

    private void SpawnEnemies()
    {
        if (waves[currWaveCount].spawnCount < waves[currWaveCount].waveQuantity && !maxEnemiesReached)
        {
            foreach (var enemyType in waves[currWaveCount].enemyTypes)
            {
                if (enemyType.spawnCount < enemyType.enemyCount)
                {
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    Vector3 spawnPos = player.position + spawnPosition[Random.Range(0, spawnPosition.Count)].position;
                    Quaternion rot = Quaternion.identity;
                    Transform enemy = EnemySpawn.Instance.Spawn(enemyType.enemyPrefab.transform, spawnPos, rot);
                    enemy.gameObject.SetActive(true);

                    enemyType.spawnCount++;
                    waves[currWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }

        if (enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }
    public void OnEnemyKilled()
    {
        enemiesAlive--;
    }

    private IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);
        if (currWaveCount < waves.Count - 1)
        {
            currWaveCount++;
            CalculateWaveQuantity();
        }

    }
}
