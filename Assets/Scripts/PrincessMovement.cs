using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessMovement : CharacterMovement
{
	public float jumpForce = 5.0f;
	public KeyCode jumpKey = KeyCode.Space;


	// Update is called once per frame
	protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        animator.SetBool("isJumping", !isGrounded);
    }

	private void Jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, 0); // Reset Y velocity before applying jump force
		rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		isGrounded = false;

		//OnPrincessJump?.Invoke();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
			animator.SetBool("isJumping", false);

			Debug.Log("Princess landed, isGrounded: " + isGrounded);
		}
	}

	private IEnumerator ResetGrounded()
	{
		yield return new WaitForFixedUpdate();//small delay
		isGrounded = true;

		animator.SetBool("isJumping", false);
	}
}
