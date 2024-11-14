using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertical : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 screenBounds;
    private Vector2 direction;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        direction = Vector2.down; 
        Respawn();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < -screenBounds.y - 1)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        float spawnPositionY = screenBounds.y;
        transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), spawnPositionY);
        direction = Vector2.down;
    }
}
