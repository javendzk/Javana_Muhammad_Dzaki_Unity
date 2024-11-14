using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    public int damage = 10;
    private Rigidbody2D rb;
    private IObjectPool<Bullet> pool;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
    }

    void Update()
    {
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        this.pool = pool;
    }

    public void Shoot()
    {
        if (pool != null && rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && pool != null)
        {
            pool.Release(this);
        }
    }

    private void OnBecameInvisible()
    {
        if (pool != null)
        {
            pool.Release(this);
        }
    }
}
