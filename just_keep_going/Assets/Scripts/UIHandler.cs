using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Slider HealthBar;
    public Slider EnergyBar;

    public GameObject Player;


    public Text txt;
    
    public int RoomCount;

    /*public Text TimerText; 
    public bool playing;
    private float Timer;*/

    
    void Start(){
       
        RoomCount = 1;
        txt.text = "Rooms: " + RoomCount;

    }

    // Update is called once per frame
    void Update()
    {
        if(Player == null){
            Player = GameObject.FindWithTag("Player");
        }
        else{

            int health = (int) (Player.GetComponent<PlayerEnergyHealth>().getCurrentHealth() / Player.GetComponent<PlayerEnergyHealth>().getMaxHealth()) * 7;
            HealthBar.GetComponent<BarScript>().setValue(health);

            int energy = (int) (Player.GetComponent<PlayerEnergyHealth>().getCurrentEnergy() / Player.GetComponent<PlayerEnergyHealth>().getMaxEnergy()) * 7;
            EnergyBar.GetComponent<BarScript>().setValue(energy);
        }

      /*  Timer += Time.deltaTime;
	    int minutes = Mathf.FloorToInt(Timer / 60F);
	    int seconds = Mathf.FloorToInt(Timer % 60F);
	    int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
	    TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString("00");*/
    }

    public void IncreaseRoomCount(int i = 1){
        RoomCount += i;
        txt.text = "Rooms: " + RoomCount;
    }
}
