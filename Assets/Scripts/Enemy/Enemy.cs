using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int level; 
    public EnemySpawner enemySpawner;
    
    public int GetLevel()
    {
        return level;
    }
    
    void OnDestroy()
    {
        if (enemySpawner != null)
        {
            enemySpawner.OnEnemyKilled();
        }
    }
}
