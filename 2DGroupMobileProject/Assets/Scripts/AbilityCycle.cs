using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image image;
    AbilityUnlock abilityUnlock;
    // Start is called before the first frame update
    void Start()
    {
        currentAbility = Ability.Fire;  // Set default ability
        image.color = Color.red;
        shootFire = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShootFire>();
        shootWater = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShootWater>();
        shootWind = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShootWind>();
        abilityUnlock = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AbilityUnlock>();
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
        if (abilityUnlock.waterUnlocked = true && currentAbility == Ability.Fire)
        {
            currentAbility = Ability.Water;
            Debug.Log("Water ability activated");
            image.color = Color.cyan;
        }
        else if (abilityUnlock.windUnlocked = true && currentAbility == Ability.Water)
        {
            currentAbility = Ability.Wind;
            Debug.Log("Wind ability activated");
            image.color = Color.white;
        }
        else if (abilityUnlock.fireUnlocked = true && currentAbility == Ability.Wind)
        {
            currentAbility = Ability.Fire;
            Debug.Log("Fire ability activated");
            image.color = Color.red;
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
