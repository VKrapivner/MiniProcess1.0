using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
	public Transform[] points; // Points the platform will move between
	public float moveSpeed = 2f;
	private int targetIndex = 0;

	private void Update()
	{
		if (points.Length == 0) return;

		// Move platform towards the target point
		transform.position = Vector2.MoveTowards(transform.position, points[targetIndex].position, moveSpeed * Time.deltaTime);

		// Check if the platform has reached the target point
		if (Vector2.Distance(transform.position, points[targetIndex].position) < 0.1f)
		{
			targetIndex = (targetIndex + 1) % points.Length; // Move to the next point
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			// Make the player a child of the platform to move along with it
			collision.collider.transform.SetParent(transform);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			// Remove the player from being a child when they leave the platform
			collision.collider.transform.SetParent(null);
		}
	}

}
