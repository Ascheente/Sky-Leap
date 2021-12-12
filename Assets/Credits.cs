using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject play;
    public GameObject logo;
    public GameObject quit;
    public GameObject credits;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back()
    {
        logo.SetActive(true);
        quit.SetActive(true);
        play.SetActive(true);
        credits.SetActive(false);
    }
}
