using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MyLoading : MonoBehaviour
{
    static string leveltoload;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(leveltoload);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static void LoadLevel(string lvl)
    {
        leveltoload = lvl;
        SceneManager.LoadScene("Loading");
    }
}
