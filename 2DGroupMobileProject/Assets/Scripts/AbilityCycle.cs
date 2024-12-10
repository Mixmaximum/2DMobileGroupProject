using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCycle : MonoBehaviour
{
    public float ShootFire;
    public float ShootWater;
    public float currentAbility;

    // Start is called before the first frame update
    void Start()
    {
        currentAbility = ShootFire; //set active ability
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Cycle() //Switch between abilities
    {
        if (currentAbility == ShootFire)
        {
            currentAbility = ShootWater;
            Debug.Log("Wata");
        }
        if (currentAbility == ShootWater)
        {
            currentAbility = ShootFire;
            Debug.Log("FIRE");
        }
    }
   
}
