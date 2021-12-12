using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ArvoreManager : MonoBehaviour
{
    public GameObject mapaSeco;
    //public TilemapRenderer tilemap;
    public GameObject plantas;
    // Start is called before the first frame update
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
            if (Input.GetKeyDown(KeyCode.LeftAlt) && playerInRange)
            {
                plantas.SetActive(true);
                mapaSeco.SetActive(false);
            }
        }
}
