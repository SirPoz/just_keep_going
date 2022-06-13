using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
 
    public GameObject[] objects;
    public GameObject levelHandler;

    private int lastRoom = -1;

    // Start is called before the first frame update
    void Start()
    {
        setupRoom();
    }

    void setupRoom()
    {
        int rand;
        do{
         rand = Random.Range(0, objects.Length);
        }while(rand == lastRoom && lastRoom != -1);
        Debug.Log(rand);
        Debug.Log(lastRoom);
        lastRoom = rand;
        
        Instantiate(objects[rand], transform.position, Quaternion.identity);
        Instantiate(levelHandler, transform.position, Quaternion.identity);
    }

    private void deleteRoom()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject levelHandlerInstance = GameObject.FindGameObjectWithTag("LevelHandler");
        GameObject room = GameObject.FindGameObjectWithTag("Room");
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.GetComponent<CameraController>().player = null;
        levelHandlerInstance.GetComponent<LevelHandler>().player = null;
        
        Destroy(levelHandlerInstance);
        DestroyImmediate(room);
        Destroy(player);
    }

    public void restartRoom()
    {
            deleteRoom();
            gameObject.GetComponent<UIHandler>().IncreaseRoomCount();
            setupRoom();
    }

}

