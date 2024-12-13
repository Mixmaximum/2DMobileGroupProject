using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCycle : MonoBehaviour
{
    public enum Ability
    {
        Fire,
        Water,
        Wind,
    }

    public Ability currentAbility;
    public PlayerShootFire shootFire;
    public PlayerShootWater shootWater;
    public PlayerShootWind shootWind;
    float shootDelay = 0.5f;  // Delay between shots
    float timer = 0;  // Timer for delay
    bool buttonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        currentAbility = Ability.Fire;  // Set default ability
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;  // Update timer
        // Check if the shoot button is pressed
        if ((Input.GetButton("Fire2") || buttonPressed) && timer > shootDelay && Time.timeScale != 0)
        {
            ShootAbility();  // Call the ShootAbility function
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cycle();
        }
    }
    //establish when the button is up and down for shooting
    public void ButtonDown()
    { 
        buttonPressed = true;
    }

    public void ButtonUp()
    {
        buttonPressed = false;
    }

    // Cycle through abilities
    public void Cycle()
    {
        if (currentAbility == Ability.Fire)
        {
            currentAbility = Ability.Water;
            Debug.Log("Water ability activated");
        }
        else if (currentAbility == Ability.Water)
        {
            currentAbility = Ability.Wind;
            Debug.Log("Wind ability activated");
        }
        else if (currentAbility == Ability.Wind)
        {
            currentAbility = Ability.Fire;
            Debug.Log("Fire ability activated");
        }
    }

    // Trigger shooting based on current ability
    public void ShootAbility()
    {
        if (currentAbility == Ability.Fire)
        {
            shootFire.Shoot();  //Shoot Fire 
        }
        else if (currentAbility == Ability.Water)
        {
            shootWater.Shoot();  //Shoot Water 
        }
        else if (currentAbility == Ability.Wind)
        {
            shootWind.Shoot(); // Shoot Wind
        }
            timer = 0;  // Reset the shoot timer
    }
}
