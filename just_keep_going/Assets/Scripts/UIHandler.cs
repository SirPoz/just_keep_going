using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    /*public Slider HealthBar;
    public Slider EnergyBar;*/

    public GameObject Player;
    public GameObject upgradeMenuUI;
    public GameObject portal;

    /*public Text txt;
    
    public int RoomCount;*/

    /*public Text TimerText; 
    public bool playing;
    private float Timer;*/

    
    void Start(){
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        if (portal == null)
        {
            portal = GameObject.FindWithTag("Portal");
        }
        upgradeMenuUI.SetActive(false);
        /*RoomCount = 1;
        txt.text = "Rooms: " + RoomCount;*/

    }

    // Update is called once per frame
    void Update()
    {

        /*else{

            int health = (int) (Player.GetComponent<PlayerEnergyHealth>().getCurrentHealth() / Player.GetComponent<PlayerEnergyHealth>().getMaxHealth()) * 7;
            HealthBar.GetComponent<BarScript>().setValue(health);

            int energy = (int) (Player.GetComponent<PlayerEnergyHealth>().getCurrentEnergy() / Player.GetComponent<PlayerEnergyHealth>().getMaxEnergy()) * 7;
            EnergyBar.GetComponent<BarScript>().setValue(energy);
    }*/

        /*  Timer += Time.deltaTime;
          int minutes = Mathf.FloorToInt(Timer / 60F);
          int seconds = Mathf.FloorToInt(Timer % 60F);
          int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
          TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString("00");*/
    }

    public void HealthButtonClick()
    {
        Player.GetComponent<PlayerEnergyHealth>().setMaxHealth(Player.GetComponent<PlayerEnergyHealth>().getMaxHealth() + 50);
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        portal.GetComponent<portalCollider>().loadNewScene();
    }

    public void DamageButtonClick()
    {
        Player.GetComponent<PlayerMovement>().attackDamage = Player.GetComponent<PlayerMovement>().attackDamage + 5;
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        portal.GetComponent<portalCollider>().loadNewScene();
    }

    public void SpeedButtonClick()
    {
        Player.GetComponent<PlayerMovement>().moveSpeed = Player.GetComponent<PlayerMovement>().moveSpeed + 1;
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        portal.GetComponent<portalCollider>().loadNewScene();
    }

    public void IncreaseRoomCount(int i = 1){
        Time.timeScale = 0f;
        upgradeMenuUI.SetActive(true);
        /*RoomCount += i;
        txt.text = "Rooms: " + RoomCount;*/
    }
}
