using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : CharacterMovement
{
    public Transform princessTransform;
    public float followDistance = 3.0f;

	//   protected override void Update()
	//{
	//	if (princessTransform != null)
	//	{
	//		FollowPrincess();
	//	}
	//	else
	//	{
	//		Debug.LogError("Princess Transform not assigned to CatMovement on " + gameObject.name);
	//	}
	//}

	protected override void Update()
	{
		// Ensure the cat only moves if the princess transform is assigned
		if (princessTransform != null)
		{
			// Check the distance first
			float distanceToPrincess = Vector2.Distance(transform.position, princessTransform.position);

			if (distanceToPrincess > followDistance)
			{
				FollowPrincess();
			}
			else
			{
				// If within follow distance, set movement to zero
				movement = Vector2.zero;
				animator.SetFloat("SpeedParam", 0);
			}
		}
		else
		{
			Debug.LogError("Princess Transform not assigned to CatMovement on " + gameObject.name);
		}
	}


	private void FollowPrincess()
    {
		if (princessTransform == null)
		{
			Debug.LogError("Princess Transform is null in FollowPrincess");
			return;
		}

		float distanceToPrincess = Vector2.Distance(transform.position, princessTransform.position);

        //If too far away moving towards princess
        if(distanceToPrincess > followDistance)
        {
            Vector2 direction = (princessTransform.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);
        }
        else
        {
            movement = Vector2.zero;
        }


        if (rb != null)
        {
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        }

		animator.SetFloat("SpeedParam", Mathf.Abs(movement.x));
		if (movement.x != 0)
		{
			transform.localScale = new Vector3(Mathf.Sign(movement.x) * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
		}

		//base.FixedUpdate();
	}
}
