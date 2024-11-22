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
			//Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
		}
		else
		{
			//Debug.Log("Rigidbody2D successfully assigned for " + gameObject.name);
		}
		//Debug.Log("Character initial position: " + transform.position);
		//Debug.Log("Initial movement: " + movement);
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		originalScale = transform.localScale;
		movement = Vector2.zero;


	}

	// Update is called once per frame
	protected virtual void Update()
    {
		Move(); 
		animator.SetBool("isGrounded", isGrounded);
    }

	protected virtual void FixedUpdate()
	{

		rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

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
