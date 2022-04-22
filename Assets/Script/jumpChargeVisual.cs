using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;


public class jumpChargeVisual : MonoBehaviour
{

    [SerializeField]
    private Image imagePowerUp;

    public float JumpForce;
    public bool isCharging = false;
    private bool isDirectionUp = true;
    private float amtPower = 0.0f;
    public float barChargeSpeed = 100.0f;
    // Update is called once per frame

    private void Start()
    {
        JumpForce = gameObject.GetComponent<fishJumpControls>().JumpForce;
        
    }
    void Update()
    {
       // JumpForce = gameObject.GetComponent<fishJumpControls>().JumpForce; 
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
        if (imagePowerUp.fillAmount > 0.22f)
        {
            imagePowerUp.fillAmount = 0.22f;
        }

        imagePowerUp.fillAmount = (0.49f - 0.22f) * amtPower / 100.0f + 0.22f;
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

