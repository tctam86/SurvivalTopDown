using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject meleePrefab;
    [SerializeField] private GameObject rangedPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float waveDelay = 2f;

    private int waveNumber;
    private float nextWaveTime;
    private List<GameObject> aliveEnemies = new List<GameObject>();

    private void Update()
    {
        aliveEnemies.RemoveAll(e => e == null);
        if (aliveEnemies.Count == 0 && Time.time >= nextWaveTime) SpawnWave();
    }


    private void SpawnWave()
    {
        waveNumber++;
        Debug.Log($"Wave {waveNumber}");
        int meeleCount = Random.Range(3, 5);
        for (int i = 0; i < meeleCount; i++)
        {
            SpawnEnemy(meleePrefab);
        }
        int rangedCount = Random.Range(1, 3);
        for (int i = 0; i < rangedCount; i++)
        {
            SpawnEnemy(rangedPrefab);
        }
        nextWaveTime = Time.time + waveDelay;
    }
    
    private void SpawnEnemy(GameObject prefab)
    {
        Vector2 circle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 pos = player.position + new Vector3(circle.x, 0.5f, circle.y);
        GameObject enemy = Instantiate(prefab, pos, Quaternion.identity);
        aliveEnemies.Add(enemy);
    }
}
