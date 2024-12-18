using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "PlayerBullet" && collision.gameObject.tag != "FireBullet" && collision.gameObject.tag != "WaterBullet")
        {
            Destroy(gameObject);
        }
    }
}
