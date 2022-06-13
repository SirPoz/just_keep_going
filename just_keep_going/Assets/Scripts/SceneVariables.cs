using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVariables : MonoBehaviour
{
    public static SceneVariables Instance{ get; private set; }
    public int roomCount;
    public int playerMaxHealth;
    public int playerMaxEnergy;
    public GameObject player;
    public GameObject canvas;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;
        playerMaxEnergy = 100;
        playerMaxHealth = 100;
        
        player.GetComponent<PlayerEnergyHealth>().setMaxEnergy(playerMaxEnergy);
        player.GetComponent<PlayerEnergyHealth>().setMaxHealth(playerMaxHealth);
        
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Debug.Log(this.gameObject.GetInstanceID());
        //canvas.GetComponent<roomCountHandler>().setUI(roomCount,100,7);
    }

   
}
