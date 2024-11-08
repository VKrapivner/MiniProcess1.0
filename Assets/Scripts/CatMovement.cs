using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : CharacterMovement
{
    public Transform princessTransform;
    public float followDistance = 1.5f; 

    // Update is called once per frame
    protected override void Update()
    {
        if (princessTransform != null)
        {
            FollowPrincess();
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

        base.FixedUpdate();
    }
}
