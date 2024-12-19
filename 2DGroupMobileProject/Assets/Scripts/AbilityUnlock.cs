using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    public bool fireUnlocked = false;
    public bool waterUnlocked = false;
    public bool windUnlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        fireUnlocked = false;
        waterUnlocked = false;
        windUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
