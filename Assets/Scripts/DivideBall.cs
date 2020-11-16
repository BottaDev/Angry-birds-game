using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideBall : BallController
{
    public GameObject splitterBallGO;

    private void Awake()
    {
        pivot = GameObject.Find("Pivot Point").GetComponent<Transform>();
    }

    public override void Update()
    {
        if (!canDrag && Input.GetKey(KeyCode.Space))
            Divide();
    }

    private void Divide()
    {
        GameObject go = Instantiate(splitterBallGO, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = CalculateAngle(rb.velocity, 45).normalized * rb.velocity.magnitude;

        go = Instantiate(splitterBallGO, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = CalculateAngle(rb.velocity, -45).normalized * rb.velocity.magnitude;

        go = Instantiate(splitterBallGO, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = CalculateAngle(rb.velocity, 0).normalized * rb.velocity.magnitude;

        Destroy(gameObject);
    }

    Vector2 CalculateAngle(Vector2 velocity, float deviation)
    {
        float degAngle = Vector2.Angle(Vector2.right, velocity) + deviation;
        float radAngle = degAngle * Mathf.Deg2Rad;

        return new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle) * velocity.normalized.y);
    }
}