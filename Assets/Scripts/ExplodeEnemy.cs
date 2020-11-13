using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEnemy : BallController
{
    public GameObject explosionGO;

    private void Awake()
    {
        pivot = GameObject.Find("Pivot Point").GetComponent<Transform>();
    }

    private void Update()
    {
        if (!canDrag && Input.GetKey(KeyCode.Space))
            Explode();
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(explosionGO, transform.position, Quaternion.identity);
        Destroy(explosion, 0.5f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            GameObject explosion = Instantiate(explosionGO, transform.position, Quaternion.identity);
            Destroy(explosion, 0.5f);
            Destroy(gameObject);
        }
    }
}
