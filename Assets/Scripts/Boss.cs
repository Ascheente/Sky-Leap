using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public int damage;
    //private float timebtwDamage = 1.5f;

    public Slider healthBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        healthBar.value = health;
    }
}
