using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
	public int health;
	public float speed;
	private bool isMovingRight = true;
	public Transform triggerSideChange;

	private void Update()
	{

		if (health <= 0) {
			Destroy(gameObject);
		}


		transform.Translate(Vector2.right * speed * Time.deltaTime);

        //makes sure the raycast hits the ground layer
		RaycastHit2D raycastGround = Physics2D.Raycast(triggerSideChange.position, Vector2.down, 1, LayerMask.GetMask("Ground"));
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

	public void EnemyTakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("Damage Taken");
	}
}
