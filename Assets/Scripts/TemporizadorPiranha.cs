using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporizadorPiranha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col )
    {
        if (col.collider.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        else if (col.collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
