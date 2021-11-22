using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Death();
        }
    }

    void Death()
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
