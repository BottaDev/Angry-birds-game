using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BallController : MonoBehaviour
{
	public Transform pivot;	
	protected float dragRange = 1f;
	protected float speed = 15f;

	protected bool canDrag = true;
	private Vector3 dragDistance;
	protected Rigidbody2D rb;

	public virtual void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.bodyType = RigidbodyType2D.Kinematic;
	}

	private void OnMouseUp()
	{
		if (!canDrag)
			return;

		canDrag = false;

		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.velocity = -dragDistance.normalized * speed * dragDistance.magnitude / dragRange;

		LevelManager.instance.AddAttempt();
	}

	private void OnMouseDrag()
	{
		if (!canDrag)
			return;

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		dragDistance = mousePosition - pivot.position;
		dragDistance.z = 0;

		if (dragDistance.magnitude > dragRange)
			dragDistance = dragDistance.normalized * dragRange;

		transform.position = dragDistance + pivot.position;
	}
}
