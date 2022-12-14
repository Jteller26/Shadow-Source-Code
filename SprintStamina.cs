using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintStamina : MonoBehaviour
{
    private float startingStamina = 100;
    public float currentStamina;
    public Slider slider;
    
    void Start()
    {
        currentStamina = startingStamina;
    }

    // Update is called once per frame
    void Update()
    {
        currentStamina += .04f;
        slider.value = currentStamina;

        if (currentStamina >= 100)
        {
            currentStamina = 100;
        }
    }

    public void DownStamina(float amount)
    {
        currentStamina -= amount;
        slider.value = currentStamina;
    }
}
