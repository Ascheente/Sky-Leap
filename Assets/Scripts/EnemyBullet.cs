using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float dieTime, damage;
    public GameObject diePEFFECT;
    
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        
        Die();

    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);

        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
