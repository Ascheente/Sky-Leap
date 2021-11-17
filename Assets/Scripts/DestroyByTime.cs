using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroyTime = 0.3f;
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
