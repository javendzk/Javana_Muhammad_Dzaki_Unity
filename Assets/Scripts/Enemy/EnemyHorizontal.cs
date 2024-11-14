using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    [SerializeField]
    private float speed = 5f;
    private Vector2 screenBounds;
    private Vector2 direction;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Respawn();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x < -screenBounds.x - 1 || transform.position.x > screenBounds.x + 1)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        float spawnPositionX;
        if (direction == Vector2.right) 
        {
            spawnPositionX = screenBounds.x;
            direction = Vector2.left; 
        }
        else
        {
            spawnPositionX = -screenBounds.x;
            direction = Vector2.right; 
        }
        transform.position = new Vector2(spawnPositionX, Random.Range(-screenBounds.y, screenBounds.y));
    }
}
