using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;
    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;
    public CombatManager combatManager;
    public bool isSpawning = false;

    public void StartNextWave()
    {
        if (combatManager.waveNumber >= spawnedEnemy.GetLevel())
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        isSpawning = true;
        spawnCount = (spawnedEnemy.GetLevel() <= combatManager.waveNumber) ? defaultSpawnCount : 0;

        while (spawnCount > 0)
        {
            Enemy enemyInstance = Instantiate(spawnedEnemy, transform);
            enemyInstance.enemySpawner = this;
            spawnCount--;
            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;
    }

    public void OnEnemyKilled()
    {
        totalKill++;
        totalKillWave++;

        if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            defaultSpawnCount += spawnCountMultiplier;
            totalKillWave = 0;
        }

        if (combatManager != null)
        {
            combatManager.OnEnemyKilled(spawnedEnemy.GetLevel());
        }
    }

    public void UpdateTotalEnemies()
    {
        combatManager.totalEnemies += defaultSpawnCount;
    }
}