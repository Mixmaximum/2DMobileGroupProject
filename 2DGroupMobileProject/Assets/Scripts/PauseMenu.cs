using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    string teleportLocation = "SampleScene";
    [SerializeField]
    string menuTeleport = "Main Menu";
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if you press the escape key
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                //make the pause menu visable
                GetComponent<Canvas>().enabled = true;
                //also, stop the game from playing
                Time.timeScale = 0;
            }
            else
            {
                Resume();
            }
        }
    }
    public void Resume()
    {
        GetComponent<Canvas>().enabled = false;
        //reset the time scale
        Time.timeScale = 1;
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuTeleport);
    }
    public void Beginning()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(teleportLocation);
    }
}
