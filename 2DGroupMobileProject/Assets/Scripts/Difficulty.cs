using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public float activeDifficulty;
    public float easy = 0;
    public float medium = 5;
    public float hard = 10;
    // Start is called before the first frame update
    void Start()
    {
        //activeDifficulty = easy;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Easy()
    {
        activeDifficulty = easy;
    }
    public void Medium()
    {
        activeDifficulty = medium;
    }
    public void Hard()
    {
        activeDifficulty = hard;
    }
}
