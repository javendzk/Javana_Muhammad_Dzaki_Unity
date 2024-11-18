using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 0;
    public int totalEnemies = 0;

    private void Start()
    {
        UpdateTotalEnemies();
    }

    private void Update()
    {
        if (timer >= waveInterval)
        {
            waveNumber++;
            timer = 0;
            NotifySpawners();
            UpdateTotalEnemies();
        }
        else if (totalEnemies <= 0 || waveNumber == 0)
        {
            timer += Time.deltaTime;
        }
    }

    private void NotifySpawners()
    {
        foreach (var spawner in enemySpawners)
        {
            spawner.StartNextWave();
        }
    }

    private void UpdateTotalEnemies()
    {
        totalEnemies = 0;
        foreach (var spawner in enemySpawners)
        {
            if (spawner.isSpawning)
            {
                spawner.UpdateTotalEnemies();
            }
        }
    }

    public void OnEnemyKilled()
    {
        totalEnemies--;
    }
}