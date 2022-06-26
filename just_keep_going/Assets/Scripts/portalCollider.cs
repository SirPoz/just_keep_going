using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalCollider : MonoBehaviour
{
    public GameObject Player;
    public GameObject upgradeMenuUI;
    private bool activated;
    

    void Start(){
        Player = GameObject.FindWithTag("Player");
        activated = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!activated)
        {
            Time.timeScale = 0f;
            upgradeMenuUI.SetActive(true);
            Debug.Log("OnTriggerEnter2D");
            activated = true;
        }
   
    }

    public void loadNewScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i+1);
    }


}
