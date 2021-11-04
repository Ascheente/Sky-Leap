using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float range;
    public Transform target;
    bool detected = false;
    Vector2 direction;
    public GameObject alarmLight;

    public GameObject gun;

    public GameObject bullet;
    public float fireRate;

    public Transform shootPoint;
    float nextTimeToFire = 0;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position; 

        direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,direction, range);

        if(rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(detected == false)
                {
                    detected = true;
                    alarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                 if(detected == true)
                {
                    detected = false;
                    alarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
            if(detected)
            {
                gun.transform.up = direction;
                if(Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time+1/fireRate;
                    shoot();
                }
            }
        }
    }

    void shoot()
    {
        GameObject bulletIns = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        bulletIns.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
