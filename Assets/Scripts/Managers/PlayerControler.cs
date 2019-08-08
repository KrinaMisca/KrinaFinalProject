using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public float jumpForce;
	public float speed;
	private float moveInput;
	private bool facingRight = true;
	private Rigidbody2D rb;

	//--------Variables for the jumping mechanics--------//
	bool isGrounded { get { return Physics2D.Raycast(transform.position, new Vector2(0, -1));} }
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
        Debug.Log(Physics2D.Raycast(transform.position, new Vector2(0, -1)));
		if (isGrounded == true) {
			numberOfJumps = maxNumbeOfJumps;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && numberOfJumps > 0) {
			rb.velocity = Vector2.up * jumpForce;
			numberOfJumps--;
		} 		
	}

    //physics for fixed update
	private void FixedUpdate()
	{
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