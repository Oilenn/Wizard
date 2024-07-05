using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // �������� �����

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("���� ������� " + amount + " �����! �������� " + health + " ��������.");

        if (health <= 0)
        {
            // ���� ���������
            Destroy(gameObject);
        }

        Debug.Log(health);
    }
}
