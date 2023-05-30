using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int point;
    
    private Rigidbody2D rb;
    [Header("Attributes")]
    [SerializeField] public float moveSpeed = 2f;

    private Transform target;
    private int pathIndex; 
    private void Start()
    {
        target = PathFinding.main.path[pathIndex];
        rb = GetComponent<Rigidbody2D>();
        rb.angularDrag = 10f;
        rb.AddTorque(10f);
        rb.useAutoMass = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            if(pathIndex >= PathFinding.main.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = PathFinding.main.path[pathIndex];
            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
