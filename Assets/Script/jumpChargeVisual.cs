using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;


public class jumpChargeVisual : MonoBehaviour
{

    [SerializeField]
    private Image imagePowerUp;


    public bool isCharging = false;
    private bool isDirectionUp = true;
    private float amtPower = 0.0f;
    public float barChargeSpeed = 100.0f;
    // Update is called once per frame
    void Update()
    {
        if (isCharging)
        {
            PowerActive();
        }
        else
        {
            EndPowerUp();
        }
    }

    void PowerActive()
    {

        amtPower += Time.deltaTime * barChargeSpeed;
        if (amtPower > 100)
        {
            amtPower = 100.0f;
        }
        if (imagePowerUp.fillAmount > 0.24f)
        {
            imagePowerUp.fillAmount = 0.24f;
        }

        imagePowerUp.fillAmount = (0.50f - 0.24f) * amtPower / 100.0f + 0.24f;
    }

    public void StartPowerUp()
    {
        isCharging = true;
        amtPower = 0.0f;
        isDirectionUp = true;


    }


    public void EndPowerUp()
    {
        isCharging = false;
        amtPower = 0.0f;
    }
}

