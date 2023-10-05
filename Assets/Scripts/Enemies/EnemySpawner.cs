using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab.
    public float spawnInterval = 2f; // Time interval between enemy spawns.
    public int groupSize = 3; // Number of enemies to spawn in each group.
    public float spawnRadius = 5f; // Radius within which enemies spawn.

    private Transform player; // Reference to the player's transform.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnEnemyGroup", 0f, spawnInterval);
    }

    void SpawnEnemyGroup()
    {
        for (int i = 0; i < groupSize; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemyPrefab, (Vector2)transform.position + randomPosition, Quaternion.identity);
        }
    }
}

