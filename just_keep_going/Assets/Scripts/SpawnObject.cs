using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
 
    public GameObject[] objects;
    public GameObject levelHandler;

    // Start is called before the first frame update
    void Start()
    {
        setupRoom();
    }

    void setupRoom()
    {

        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity);
        Instantiate(levelHandler, transform.position, Quaternion.identity);
    }

    private void deleteRoom()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject levelHandlerInstance = GameObject.FindGameObjectWithTag("LevelHandler");
        GameObject room = GameObject.FindGameObjectWithTag("Room");
       Destroy(room);
       Destroy(levelHandlerInstance);
       Destroy(player);
    }

    public void restartRoom()
    {
        deleteRoom();
        setupRoom();
    }

}

