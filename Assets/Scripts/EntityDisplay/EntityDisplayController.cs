using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDisplayController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
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

        if (transform.position.y < -screenBounds.y - 1 || transform.position.y > screenBounds.y + 1)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        float spawnPositionY = screenBounds.y + 1;
        float spawnPositionX;
        if (Random.value > 0.5f)
        {
            spawnPositionX = Random.Range(5f, 8.5f);
        }
        else
        {
            spawnPositionX = Random.Range(-8.5f, -5f);
        }

        transform.position = new Vector3(spawnPositionX, spawnPositionY, -1); 
        direction = Vector2.down;
    }
}
