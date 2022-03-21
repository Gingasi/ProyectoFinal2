using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    


    public void SetMaxHealth (int health) //Indicamos la vida máxima y la vinculamos al gradient de color. 
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health) // Indicamos como es la vida actual y comop obtenerla. 
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

   

}
