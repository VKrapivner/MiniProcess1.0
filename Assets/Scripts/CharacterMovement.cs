using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public Animator animator;
	public float moveSpeed = 1.0f;
	[SerializeField] protected Rigidbody2D rb;
	protected Vector2 movement;
	protected bool isGrounded = true;
	protected Vector3 originalScale;

	// Start is called before the first frame update
	protected virtual void Start()
    {

		if (rb == null)
		{
			Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
		}
		else
		{
			Debug.Log("Rigidbody2D successfully assigned for " + gameObject.name);
		}

		originalScale = transform.localScale;
		
	}

    // Update is called once per frame
    protected virtual void Update()
    {
		Move(); 
    }

	protected virtual void FixedUpdate()
	{
		//if (rb != null && movement.x != 0)
		//{
		//	rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
		//}
		//else
		//{
		//	rb.velocity = new Vector2(0, rb.velocity.y);
		//	Debug.LogError("Rigidbody2D is null in FixedUpdate for " + gameObject.name);
		//}

		rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
		
		//if (movement.x != 0)
		//{
		//	rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
		//}
		//else
		//{
		//	rb.velocity = new Vector2(0, rb.velocity.y);
		//}
	}

	protected void Move()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		movement = new Vector2(moveX, 0);
		animator.SetFloat("SpeedParam", Mathf.Abs(movement.x));

		// Flip the character based on movement direction
		if (moveX != 0)
		{
			transform.localScale = new Vector3(Mathf.Sign(moveX) * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
		}

	}
}
