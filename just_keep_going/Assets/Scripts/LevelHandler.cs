using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;

    public GameObject camera;

    public GameObject spawn;
    public GameObject end;

    public GameObject GameController;
    // Start is called before the first frame update
    void Start()
    {
            
        camera = GameObject.FindWithTag("MainCamera");
        GameController= GameObject.FindWithTag("GameController");

        spawn = GameObject.FindWithTag("Respawn");
        end = GameObject.FindWithTag("Finish");
        Debug.Log(spawn);

        player = (GameObject)Instantiate(prefab, spawn.transform.position, Quaternion.identity);
  
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player != null && end != null && spawn != null){
            float dist = Vector3.Distance(player.transform.position,end.transform.position);
            if(dist < 2){
                Debug.Log("Won");
                GameController.GetComponent<SpawnObject>().restartRoom();
                //player.transform.position = spawn.transform.position;
            }
        }
        else
        {
            spawn = GameObject.FindWithTag("Respawn");
            end = GameObject.FindWithTag("Finish");
        }
    }
}
