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
    public float fireDamage = 1;
    public float maxFireDur = 2;
    public float fireChance = 30;
    bool onFire = false;
    int digit;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar = GetComponentsInChildren<Image>()[1];
        healthBar.fillAmount = health / maxHealth;
        onFire = false;
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
                onFire = false;
            }
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
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
                Debug.Log("IM ON FIRE");
            }
        }
    }
}
