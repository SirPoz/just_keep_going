using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalCollider : MonoBehaviour
{
    
    private bool activated;
    

    void Start(){
        activated = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!activated)
        {
            Debug.Log("OnTriggerEnter2D");
            activated = true;
            loadNewScene();
        }
   
    }

    private void loadNewScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i+1);
    }


}
