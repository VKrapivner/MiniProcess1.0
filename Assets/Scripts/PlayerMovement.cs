using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public float moveSpeed = 1.0f;
    private Rigidbody2D rb; //Rb for the player

    private Vector2 movement;//Storing movement input

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

        if (moveX > 0)
            //transform.localScale = new Vector3(1, 1, 1); //Facing right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);  
        else if (moveX < 0)
			//transform.localScale = new Vector3(-1, 1, 1);//Facing left
			transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

	}

	private void FixedUpdate()
	{
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
	}
}
