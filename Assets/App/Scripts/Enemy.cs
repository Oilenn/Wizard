using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // Здоровье врага

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Враг получил " + amount + " урона! Осталось " + health + " здоровья.");

        if (health <= 0)
        {
            // Враг уничтожен
            Destroy(gameObject);
        }

        Debug.Log(health);
    }
}
