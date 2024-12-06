using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float health = 10;
    [SerializeField]
    string levelToLoad;
    float maxHealth;
    [SerializeField]
    Image healthBar;
    private PlayerIFrames playerIFrames;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
        playerIFrames = GetComponent<PlayerIFrames>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //we want to take damage IF the player hits the enemy capsule
        //bool key = true;
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (playerIFrames.isInvincible == false)
            {
                //health = health - 1;
                health -= 1;
                healthBar.fillAmount = health / maxHealth;
                playerIFrames.isInvincible = true;
                //health--;
                //consequences for taking damage
                //If we take damage so health is below 0, reload the level
                    if (health <= 0)
                    {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    //SceneManager.LoadScene(levelToLoad);
                    }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (playerIFrames.isInvincible == false)
            {
                health -= 1;
                healthBar.fillAmount = health / maxHealth;
                playerIFrames.isInvincible = true;
                if (health <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    //SceneManager.LoadScene(levelToLoad);
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (playerIFrames.isInvincible == false)
            {
                health -= 1;
                healthBar.fillAmount = health / maxHealth;
                playerIFrames.isInvincible = true;
                if (health <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    //SceneManager.LoadScene(levelToLoad);
                }

            }
        }
    }
}
