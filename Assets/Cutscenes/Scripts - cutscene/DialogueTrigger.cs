using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueContainer dialogueContainer;
    public GameObject cutSceneManager;
    void Start()
    {
        //DialogueManager.Instance.StartConversation(dialogueContainer);        
    }

    void OnTriggerEnter2D(Collider2D col )
    {
        if (col.tag == "Player")
        {
            DialogueManager.Instance.StartConversation(dialogueContainer);
            cutSceneManager.SetActive(true);
        }
        
    }

}
