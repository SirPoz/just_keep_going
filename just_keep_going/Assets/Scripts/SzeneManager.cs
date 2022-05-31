using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SzeneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneVariables.roomCount++;
        GameObject Player = GameObject.FindWithTag("Player");
        Player.GetComponent<PlayerEnergyHealth>().setMaxHealth(SceneVariables.playerMaxHealth);
        Player.GetComponent<PlayerEnergyHealth>().setCurrentHealth(SceneVariables.playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
