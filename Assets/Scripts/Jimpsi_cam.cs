using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jimpsi_cam : MonoBehaviour
{
    GameObject player;
    float sy,sx;
    public float limitXMin,limitXMax,limitYMin,limitYMax;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        sy = Mathf.Lerp(sy, player.transform.position.y, Time.deltaTime);
        sx = player.transform.position.x;
        sx = Mathf.Clamp(sx, limitXMin, 90000000000000);
        sy = Mathf.Clamp(sy, limitYMin, 90000000000000);

        transform.position = new Vector3(sx, sy, -10);
    }
}
