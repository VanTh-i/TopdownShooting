using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : ThaiBehaviour
{
    [SerializeField] protected List<GameObject> terrainChunks;
    [SerializeField] protected float checkerRadius;
    private Vector3 noTerrainPosition;
    [SerializeField] protected LayerMask terrainMask;
    public GameObject currentChunk;
    protected Transform poolHolder;

    [Header("---Optimization---")]
    [SerializeField] protected List<GameObject> spawnerChunk;
    protected Transform player;
    [SerializeField] protected float maxOpDist;
    private float opDist;
    private float optCooldown;
    [SerializeField] protected float optCooldownDur;

    protected override void LoadComponents()
    {
        if (poolHolder != null)
        {
            return;
        }
        poolHolder = transform.Find("Pool");

        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        ChunkCheker();
        DeSpawnChunk();
    }

    private void ChunkCheker()
    {
        Vector3 moveDir = InputManager.Instance.MoveDir;

        if (!currentChunk)
        {
            return;
        }

        if (moveDir.x > 0 && moveDir.y == 0) // right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (moveDir.x < 0 && moveDir.y == 0) // left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (moveDir.x == 0 && moveDir.y > 0) // up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (moveDir.x == 0 && moveDir.y < 0) // down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (moveDir.x > 0 && moveDir.y > 0) // right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right up").position;
                SpawnChunk();
            }
        }
        else if (moveDir.x > 0 && moveDir.y < 0) // right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right down").position;
                SpawnChunk();
            }
        }
        else if (moveDir.x < 0 && moveDir.y > 0) // left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left up").position;
                SpawnChunk();
            }
        }
        else if (moveDir.x < 0 && moveDir.y < 0) // left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left down").position;
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        int random = Random.Range(0, terrainChunks.Count);
        GameObject chunk = Instantiate(terrainChunks[random], noTerrainPosition, Quaternion.identity);
        chunk.transform.parent = poolHolder;
        spawnerChunk.Add(chunk);
    }

    private void DeSpawnChunk()
    {
        optCooldown -= Time.deltaTime;
        if (optCooldown <= 0f)
        {
            optCooldown = optCooldownDur;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnerChunk)
        {
            opDist = Vector3.Distance(player.position, chunk.transform.position);

            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }

}
