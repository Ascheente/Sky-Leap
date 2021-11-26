using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float hp = 100;
    public Transform[] spots;
    public float speed;

    public Transform[] holes;

    public GameObject projectile;

    GameObject player;

    Vector3 playerPos;

    public Sprite[] sprites;

    public bool vulnerable;
    bool dead;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine ("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0 && !dead)
        {
            dead = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
            StopCoroutine ("Boss");
            
        }
    }

    IEnumerator Boss()
    {
        while(true)
        {

        

            //fIRST MOVE
            while (transform.position.x!=spots[0].position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, transform.position.y), speed);
                yield return null;
            }

            transform.localScale = new Vector2(-1,1);
            yield return new WaitForSeconds(1f);

            int i = 0;
            while ( i < 6 )
            {
                GameObject bullet = (GameObject) Instantiate(projectile, holes[Random.Range(0,2)].position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left*5;

                i++;
                yield return new WaitForSeconds (0.7f);
            }

            //Second move
            GetComponent<Rigidbody2D>().isKinematic = true;
            while(transform.position != spots[2].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, spots[2].position, speed);
                yield return null;
            }

            playerPos = player.transform.position;

            yield return new WaitForSeconds(1f);
            GetComponent<Rigidbody2D>().isKinematic = false;

            while (transform.position.x!=playerPos.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPos.x, transform.position.y), speed);
                yield return null;
            }

            this.tag = "Untagged";
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            vulnerable = true;
            yield return new WaitForSeconds(2f);
            this.tag = "Deadly";
            GetComponent<SpriteRenderer>().sprite = sprites[0];
            vulnerable = false;

            //Third Move
            Transform temp;
            if (transform.position.x > player.transform.position.x)
            {
                temp = spots[1];
            }
            else
            {
                temp = spots[0];
            }

            while (transform.position.x!=temp.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(temp.position.x, transform.position.y), speed);
                yield return null;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col )
    {
        if (col.collider.tag == "Player" && vulnerable)
        hp-=30;
        vulnerable = false;
        GetComponent<SpriteRenderer>().sprite = sprites[0];

        if (col.collider.tag == "Dashing" )
        hp-=30;
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }
    
}
