using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public Animator animator;
	public float moveSpeed = 1.0f;
	protected Rigidbody2D rb;
	protected Vector2 movement;
	protected bool isGrounded = true;
	private Vector3 originalScale;

	// Start is called before the first frame update
	protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

		if (rb == null)
		{
			Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
		}

		originalScale = transform.localScale;
		
	}

    // Update is called once per frame
    protected virtual void Update()
    {
		Move(); 
    }

	protected void FixedUpdate()
	{
		if (rb != null)
		{
			rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
		}
		else
		{
			Debug.LogError("Rigidbody2D is null in FixedUpdate for " + gameObject.name);
		}
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
