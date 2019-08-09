using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
	public float speed;
	private bool isMovingRight = true;
	public Transform isTrigger;

	private void Update()
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		RaycastHit2D raycastGround = Physics2D.Raycast(isTrigger.position, Vector2.down, 1);
		if (raycastGround.collider == false) {
			if (isMovingRight == true)
			{
				//this flips the charachter 180 degrees
				transform.eulerAngles = new Vector3(0,-180,0);
				isMovingRight = false;
			}
			else {
				transform.eulerAngles = new Vector3(0, -0, 0);
				isMovingRight = true;
			}
			
		}
	}
	
}
