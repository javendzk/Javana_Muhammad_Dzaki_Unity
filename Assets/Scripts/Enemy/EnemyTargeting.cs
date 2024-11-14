using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 screenBounds;
    private Transform player;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Respawn();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (transform.position.x < -screenBounds.x - 1 || transform.position.x > screenBounds.x + 1)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        float spawnPositionX = Random.value > 0.5f ? screenBounds.x : -screenBounds.x;
        transform.position = new Vector2(spawnPositionX, Random.Range(-screenBounds.y, screenBounds.y));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
