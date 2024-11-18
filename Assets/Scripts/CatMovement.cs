using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CatMovement : CharacterMovement
//{
//    public Transform princessTransform;
//    public float followDistance = 3.0f;

//	public float jumpForce = 5.0f;
//	public float maxJumpDelay = 1.0f;

//	private bool princessHasJumped = false;

//	private void OnEnable()
//	{
//		PrincessMovement.OnPrincessJump += HandlePrincessJump;
//	}

//	private void OnDisable()
//	{
//		PrincessMovement.OnPrincessJump -= HandlePrincessJump;

//	}

//	protected override void Update()
//	{
//		// Ensure the cat only moves if the princess transform is assigned
//		if (princessTransform != null)
//		{
//			// Check the distance first
//			float distanceToPrincess = Vector2.Distance(transform.position, princessTransform.position);

//			if (distanceToPrincess > followDistance)
//			{
//				FollowPrincess();
//			}
//			else
//			{
//				// If within follow distance, set movement to zero
//				movement = Vector2.zero;
//				animator.SetFloat("SpeedParam", 0);
//			}

//			if (princessHasJumped && isGrounded)
//			{
//				princessHasJumped = false;
//				float delay = Mathf.Clamp(distanceToPrincess / followDistance, 0.1f, maxJumpDelay);
//				StartCoroutine(JumpAfterDelay(delay));
//			}
//		}
//		else
//		{
//			Debug.LogError("Princess Transform not assigned to CatMovement on " + gameObject.name);
//		}


//	}

//	private void HandlePrincessJump()
//	{
//		if (isGrounded)
//		{
//			princessHasJumped = true;
//		}
//	}


//	private void FollowPrincess()
//    {
//		if (princessTransform == null)
//		{
//			Debug.LogError("Princess Transform is null in FollowPrincess");
//			return;
//		}

//		float distanceToPrincess = Vector2.Distance(transform.position, princessTransform.position);

//        //If too far away moving towards princess
//        if(distanceToPrincess > followDistance)
//        {
//            Vector2 direction = (princessTransform.position - transform.position).normalized;
//            movement = new Vector2(direction.x, 0);
//        }
//        else
//        {
//            movement = Vector2.zero;
//        }


//        if (rb != null)
//        {
//            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

//        }

//		animator.SetFloat("SpeedParam", Mathf.Abs(movement.x));
//		if (movement.x != 0)
//		{
//			transform.localScale = new Vector3(Mathf.Sign(movement.x) * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
//		}

//		//base.FixedUpdate();
//	}
//	private IEnumerator JumpAfterDelay(float delay)
//	{
//		yield return new WaitForSeconds(delay);

//		if (isGrounded)
//		{
//			rb.velocity = new Vector2(rb.velocity.x, 0);
//			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//			isGrounded = false;
//			animator.SetBool("isJumping", true);
//		}
//	}

//	private void OnCollisionEnter2D(Collision2D collision)
//	{
//		if (collision.collider.CompareTag("Ground"))
//		{
//			StartCoroutine(ResetGrounded());
//		}
//	}

//	private IEnumerator ResetGrounded()
//	{
//		yield return new WaitForFixedUpdate();
//		isGrounded = true;
//		animator.SetBool("isJumping", false);
//	}

//}

public class CatMovement : CharacterMovement
{
	public Transform princessTransform;
	public float followDistance = 3.0f;
	public float jumpForce = 5.0f; // Add a jump force for the cat
	private bool isCatGrounded = true; // Separate grounded check for the cat

	protected override void Update()
	{
		if (princessTransform != null)
		{
			float distanceToPrincess = Vector2.Distance(transform.position, princessTransform.position);

			if (distanceToPrincess > followDistance)
			{
				FollowPrincess();
			}
			else
			{
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
		float distanceToPrincess = Vector2.Distance(transform.position, princessTransform.position);

		if (distanceToPrincess > followDistance)
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
	}

	private void Jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, 0); // Reset Y velocity before applying jump force
		rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		isCatGrounded = false;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Platform") && isCatGrounded)
		{
			Jump();
		}

		if (collision.collider.CompareTag("Ground"))
		{
			StartCoroutine(ResetGrounded());
		}
	}

	private IEnumerator ResetGrounded()
	{
		yield return new WaitForFixedUpdate();
		isCatGrounded = true;
	}
}
