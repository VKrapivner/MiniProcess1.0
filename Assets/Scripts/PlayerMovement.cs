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

	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		float moveX = Input.GetAxisRaw("Horizontal");

		movement = new Vector2(moveX, 0);//(x,0)
        animator.SetFloat("SpeedParam", Mathf.Abs(movement.x));//Trigger animation

        if (moveX != 0)
            transform.localScale = new Vector3(moveX, transform.localScale.y, transform.localScale.z);  
   //     else if (moveX < 0)
			//transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

		Debug.Log("isGrounded " + isGrounded);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
		{
			Debug.Log("Entered Space");
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			Debug.Log("Player jumped");
			animator.SetBool("isJumping", true);
			animator.SetBool("isGrounded", false);
		}
		rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y); // Update horizontal velocity, but keep vertical velocity

	}

	private void FixedUpdate()
	{

		//rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y); // Update horizontal velocity, but keep vertical velocity

	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Enter");
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
			animator.SetBool("isGrounded", true);
			animator.SetBool("isJumping", false);
			Debug.Log("Player is grounded");
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		Debug.Log("Exit");
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = false;
			animator.SetBool("isGrounded", false);
			Debug.Log("Player is not grounded");
		}
	}
}
