using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    private void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void EnemyTakeDamage(int damage) {
        health -= damage;
        Debug.Log("Damage Taken");
    }
}