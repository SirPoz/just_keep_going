using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyHealth : MonoBehaviour
{

    public float maxEnergy;
    public float currentEnergy;
    public float maxHealth;
    public float currentHealth;

    public float getMaxEnergy(){
        return maxEnergy;
    }

    public float getCurrentEnergy(){
        return currentEnergy;
    }

    public float getMaxHealth(){
        return maxHealth; 
    }

    public float getCurrentHealth(){
        return currentHealth;
    }

    public void setMaxEnergy(float newValue){
        maxEnergy = newValue;
    }

    public void setCurrentEnergy(float newValue){
        currentEnergy = newValue;
    }

    public void setMaxHealth(float newValue){
        maxHealth = newValue;
    }

    public void setCurrentHealth(float newValue){
        currentHealth = newValue;
    }   

    void Start()
    {
        setCurrentEnergy(getMaxEnergy());
        setCurrentHealth(getMaxHealth());
    }

    void Update()
    {
        if (getCurrentEnergy() < getMaxEnergy()) {
            setCurrentEnergy(getCurrentEnergy() + 0.01f);
        }
        if(getCurrentEnergy() > getMaxEnergy())
        {
            setCurrentEnergy(getMaxEnergy());
        }
    }
}
