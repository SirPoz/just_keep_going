using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour
{
    private Slider slider;

    public void SetEnergy(int energy)
    {
        slider.value = energy;
    }
}
