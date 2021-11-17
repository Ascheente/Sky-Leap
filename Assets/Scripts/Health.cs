using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numberOfHearts;

    public Transform player;
    public Transform respawnPoint;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                 hearts[i].sprite = emptyHeart;

            }

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Vector2 dir = collision.relativeVelocity.normalized;
            health--; 
        }
        if (collision.gameObject.tag.Equals("Deadly"))
        {
            Vector2 dir = collision.relativeVelocity.normalized;
            health--;        
        }
        if (health <= 0)
        {
            Death();
        }
        if (collision.collider.tag.Equals("DeathZone"))
        {
            Death();
        }
    }

    void Death()
    {
        health = numberOfHearts;
        player.transform.position = respawnPoint.transform.position;
    }
}
