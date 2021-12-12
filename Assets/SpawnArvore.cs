using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArvore : MonoBehaviour
{
    public GameObject arvore;
    private bool playerInRange;
    void Start()
    {
        //tilemap = GetComponent<TilemapRenderer>();
        playerInRange = false;
    }

        void OnTriggerEnter2D(Collider2D col )
        {
            if (col.tag == "Player")
            {
                // plantas.SetActive(true);
                // mapaSeco.SetActive(false);
                //tilemap.enabled = false;
                playerInRange = true;
            }
        
        }

        void OnTriggerExit2D(Collider2D col)
        {
         if (col.tag == "Player")
            {
                Destroy(this);
            }
        
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && playerInRange)
            {
                Instantiate(arvore, new Vector3(transform.position.x, transform.position.y + 4, transform.position.z + 3), Quaternion.identity);
            }
        }
}
