using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class roomCountHandler : MonoBehaviour
{
    [SerializeField]private TMP_Text roomText;
    [SerializeField]private TMP_Text healthText;
    [SerializeField]private GameObject energyBar;
    
    public void SetUI(int roomCount, int health, int energy)
    {
        roomText.text = roomCount + "";
        healthText.text = health + " %";
        //energyBar.GetComponent<EnergyBarScript>().setEnergy(energy);
    }

    public void setEnergy(int energy)
    {
        //energyBar.GetComponent<EnergyBarScript>().setEnergy(energy);
    }
    public void setHealth(int health)
    {
        healthText.text = health + " %";
    }
}
