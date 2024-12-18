using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float health = 3;
    Image healthBar;
    float maxHealth;
    float fireDur;
    [SerializeField]
    float fireDamage = 2;
    [SerializeField]
    int maxFireDur = 1;
    [SerializeField]
    float fireChance = 30;
    bool onFire = false;
    int digit;
    public ParticleSystem fireParticle;
    public Difficulty difficulty;
    float activeDifficulty;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health + activeDifficulty;
        healthBar = GetComponentsInChildren<Image>()[1];
        healthBar.fillAmount = health / maxHealth;
        onFire = false;
        fireParticle.GetComponent<Renderer>().enabled = false;
        difficulty = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Difficulty>();
        activeDifficulty = difficulty.activeDifficulty;
        fireChance = fireChance - activeDifficulty;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (onFire == true)
        {
            fireDur -= Time.deltaTime; //set time on fire to a timer

            if (fireDur > 0)
            {
            health -= fireDamage * Time.deltaTime; //deal damage over time
            healthBar.fillAmount = health / maxHealth;
            }
            if (fireDur <= 0)
            {
                fireParticle.GetComponent<Renderer>().enabled = false;
                onFire = false;
            }
            if (health <= 0.3)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet"|| collision.gameObject.tag == "WaterBullet" || collision.gameObject.tag == "WindBullet")
        {
            health -= 1;
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "FireBullet")
        {
            health -= 1;
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                Destroy(gameObject);
            }

            digit = Random.Range(0, 101);
            if (digit <= fireChance && !onFire) //chance to light on fire if not on fire
            {
                onFire = true;
                fireDur = maxFireDur;
                fireParticle.GetComponent<Renderer>().enabled = true;
                Debug.Log("IM ON FIRE");
            }
        }
    }
}
