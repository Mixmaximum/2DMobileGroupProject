using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = 10f;
    [SerializeField]
    float chaseTriggerDistance = 5.0f;
    [SerializeField]
    bool returnHome = true;
    Vector3 home;
    float activeMoveSpeed;
    float freezeLength;
    public bool isFrozen;
    [SerializeField]
    float maxFreezeLength = 2;
    int digit;
    [SerializeField]
    int freezeChance;
    public GameObject freezeCube;
    public bool isKnockedBack = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        home = transform.position;
        activeMoveSpeed = chaseSpeed;
        isFrozen = false;
        freezeCube.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFrozen && !isKnockedBack)
        {
            //if the player gets too close
            Vector3 playerPosition = player.transform.position;
            Vector3 chaseDir = playerPosition - transform.position;
            Vector3 homeDir = home - transform.position;
            if (chaseDir.magnitude < chaseTriggerDistance)
            { 
                //chase the player
                //chase direction = players position - my current position
                //move in the direction of the player
                chaseDir.Normalize();
                GetComponent<Rigidbody2D>().velocity = chaseDir * activeMoveSpeed;
            }
            else if(returnHome && homeDir.magnitude > 0.2f)
            {
                //return home
                homeDir.Normalize();
                GetComponent<Rigidbody2D>().velocity = homeDir * activeMoveSpeed;
            }
            else
            {
                //if the player is not close & we're not trying to return home, stop moving
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

        }
        if (freezeLength > 0)
        {
            freezeLength -= Time.deltaTime;
            if (freezeLength <= 0)
            {
                isFrozen = false;
                activeMoveSpeed = chaseSpeed;
                freezeCube.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("WaterBullet") && !isFrozen) //When hit by the water bullet if not frozen
        {
            digit = Random.Range(0, 101); //chance if the enemy gets frozen or not
            if (digit <= freezeChance)
            {
                isFrozen = true;
                freezeLength = maxFreezeLength; // freeze enemy and start timer
                activeMoveSpeed = 0;
                Debug.Log("IM FROZEN");
                freezeCube.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
