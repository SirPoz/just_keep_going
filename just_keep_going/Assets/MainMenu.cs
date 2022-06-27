using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play(){
        var r = new System.Random();
        int rInt = r.Next(1, 9); //for ints
        SceneManager.LoadScene(rInt);
    }
    public void quit(){
        Application.Quit();
    }
}
