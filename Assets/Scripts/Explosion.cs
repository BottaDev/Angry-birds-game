using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
            collision.GetComponent<DestructibleObject>().TakeDamage(damage);
        else if (collision.gameObject.layer == 10)
            collision.GetComponent<EnemyController>().TakeDamage(damage);
    }
}
