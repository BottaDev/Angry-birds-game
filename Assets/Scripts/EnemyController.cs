using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float baseHp = 30f;

	public float currentHp;

	private void Start()
	{
		currentHp = baseHp;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.relativeVelocity.magnitude > currentHp)
			Destroy(gameObject);
		else
			currentHp -= col.relativeVelocity.magnitude;
	}
}
