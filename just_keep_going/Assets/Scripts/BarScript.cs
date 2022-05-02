using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{

    public Slider slider;

    public void setValue(int health)
    {
        slider.value = health;
    }

}
