using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velocidade;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            BolaFogo();
        }
    }

    void BolaFogo()
    {
        rb2d.velocity = transform.up * velocidade;

    }
}
