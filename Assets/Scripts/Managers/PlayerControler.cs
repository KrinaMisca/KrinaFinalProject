using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	private float moveInput;
	private bool facingRight = true;
	private Rigidbody2D rb;

	//--------Variables for the jumping mechanics--------//
	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;
	private int numberOfJumps;
	public int maxNumbeOfJumps;
	//--------------------------------------------------//

	private void Start()
	{
		numberOfJumps = maxNumbeOfJumps;
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (isGrounded == true) {
			numberOfJumps = maxNumbeOfJumps;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && numberOfJumps > 0) {
			rb.velocity = Vector2.up * jumpForce;
			numberOfJumps--;
		} else if (Input.GetKeyDown(KeyCode.UpArrow) && numberOfJumps == 0 && isGrounded == true) {
			rb.velocity = Vector2.up * jumpForce;
		}
		
	}
	private void FixedUpdate()
	{
		//--------------------Jumping Mechanics--------------------//
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

		//---------------------------------------------------------//

		//--------------------LeftAndRightMovement--------------------//
		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		if (facingRight == false && moveInput > 0) {
			Flip();
		} else if (facingRight == true && moveInput < 0) {
			Flip();
		}
		//----------------------------------------------------------//
	}

	private void Flip() {
		facingRight = !facingRight;
		Vector3 scaler = transform.localScale;
		scaler.x  *= -1;
		transform.localScale = scaler;
	}
}