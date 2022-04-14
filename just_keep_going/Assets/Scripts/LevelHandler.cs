using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;

    public GameObject spawn;
    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindWithTag("Respawn");
        end = GameObject.FindWithTag("Finish");
        player = (GameObject)Instantiate(prefab, spawn.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position,end.transform.position);
        if(dist < 2){
            Debug.Log("Won");
            player.transform.position = spawn.transform.position;
        }
    }
}
