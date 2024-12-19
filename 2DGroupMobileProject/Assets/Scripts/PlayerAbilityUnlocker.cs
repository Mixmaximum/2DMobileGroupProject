using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityUnlocker : MonoBehaviour
{
    public AbilityUnlock abilityUnlock;
    // Start is called before the first frame update
    void Start()
    {
        abilityUnlock = GameObject.FindWithTag("GameManager").GetComponent<AbilityUnlock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "FireUnlocker")
        {
            abilityUnlock.fireUnlocked = true;
        }
        if (gameObject.tag == "WaterUnlocker")
        {
            abilityUnlock.waterUnlocked = true;
        }
        if (gameObject.tag == "WindUnlocker")
        {
            abilityUnlock.windUnlocked = true;
        }
    }
}
