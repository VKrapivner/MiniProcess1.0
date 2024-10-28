using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
    public Animator animator;
    public float moveSpeed = 1.0f;
    private Rigidbody2D rb; //Rb for the player

    private Vector2 movement;//Storing movement input

	public float jumpForce = 5.0f;
    private bool isGrounded = true;

	public string horizontalInput = "Horizontal";
	public KeyCode jumpKey = KeyCode.Space;

	private Vector3 originalScale;

	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
		float moveX = Input.GetAxisRaw("Horizontal");

		movement = new Vector2(moveX, 0);//(x,0)
        animator.SetFloat("SpeedParam", Mathf.Abs(movement.x));//Trigger animation
		Debug.Log("SpeedParam: " + Mathf.Abs(movement.x));


		if (moveX != 0)
			//transform.localScale = new Vector3(moveX, transform.localScale.y, transform.localScale.z);  
			transform.localScale = new Vector3(Mathf.Sign(moveX) * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

		if (animator.HasParameter("isJumping") && Input.GetKeyDown(jumpKey))
		{
			animator.SetBool("isJumping", true);
		}

		if (Input.GetKeyDown(jumpKey) && isGrounded == true)
		{
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			animator.SetBool("isJumping", true);
			animator.SetBool("isGrounded", false);
		}
		//rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y); // Update horizontal velocity, but keep vertical velocity

	}

	private void FixedUpdate()
	{

		rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y); // Update horizontal velocity, but keep vertical velocity

	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
			animator.SetBool("isGrounded", true);
			animator.SetBool("isJumping", false);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = false;
			animator.SetBool("isGrounded", false);
		}
	}

}
