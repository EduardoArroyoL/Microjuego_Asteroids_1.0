using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bigEnemyPrefab;
    public float spawnRate = 1.5f;

    public float spawnX = 10f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector3 pos = new Vector3(
            spawnX,
            Random.Range(minY, maxY),
            0);
        if (Random.value < 0.25f)
        {
            Instantiate(bigEnemyPrefab, pos, Quaternion.Euler(0, 0, -90));
        }else
        {
            Instantiate(enemyPrefab, pos, Quaternion.Euler(0, 0, -90));
        }
    }
}