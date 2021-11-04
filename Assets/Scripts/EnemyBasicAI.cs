using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAI : MonoBehaviour
{
    GameObject target;
    Rigidbody2D rdb;
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (target)
        {
            Vector2 dir = target.transform.position - transform.position;
            rdb.AddForce(dir);
            rdb.gravityScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            target = collision.gameObject;
        }
    }
}
