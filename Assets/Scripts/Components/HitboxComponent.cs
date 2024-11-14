using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent health;

    void Start()
    {
        health = GetComponent<HealthComponent>();
    }

    public void Damage(int damage)
    {
        health.Subtract(damage);
    }

    public void Damage(Bullet bullet)
    {
        health.Subtract(bullet.damage);
    }

    void Update()
    {
        
    }
}
