using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        MyLoading.LoadLevel("Level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void menu()
    {
        MyLoading.LoadLevel("Menu");
    }
    public void credits()
    {
        MyLoading.LoadLevel("Creditos");
    }
   

}
