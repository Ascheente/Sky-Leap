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

    void OnTriggerEnter2D(Collider2D col )
    {
        if (col.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        // else if (col.tag == "Player")
        // {
        //     Destroy(this.gameObject);
        // }
    }
}
