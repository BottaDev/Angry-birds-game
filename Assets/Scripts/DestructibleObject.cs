using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
	public float resistance;
	public Sprite brokenSprite;
	public GameObject explosionPrefab;

	private float currentResistence;
	private bool isBroken;

	private void Start()
	{
		currentResistence = resistance;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.relativeVelocity.magnitude > currentResistence)
		{
			if (explosionPrefab != null)
			{
				GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

				Destroy(explosionObject, 3);
			}

			Destroy(gameObject);
		}
		else
		{
			currentResistence -= col.relativeVelocity.magnitude;
			if (currentResistence <= resistance / 2 && !isBroken)
			{
				isBroken = true;
				GetComponent<SpriteRenderer>().sprite = brokenSprite;
			}
		}
	}
}
