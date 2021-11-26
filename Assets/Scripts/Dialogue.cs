using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;
    private DialogueControl dc;

    private bool canTalk = true;

    //detection 
    private bool playerInRange;



    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
        playerInRange = false;
    }

    private void FixedUpdate()
    {
        //Interact(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && canTalk)
        {
            dc.Speech(profile, speechTxt, actorName);
            canTalk = false;
        }
    }

    //

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)   
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
   // public void Interact()
   // {
      //  Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

     //   if(hit != null)
      //  {
//            dc.Speech(profile, speechTxt, actorName);
        //}

   // }
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawWireSphere(transform.position, radious);
    //}

}
