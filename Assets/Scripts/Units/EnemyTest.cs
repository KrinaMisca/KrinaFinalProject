using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public int health;
    public float speed;
    private bool isMovingRight = true;
    public Transform triggerSideChange;

    Animator animator;
    // ------ Enemy Attack test ------ //
    public LayerMask playerMask;
    public Transform positionOfAttack;
    public float attackRange;
    int damage = 1;
    private bool playerInRange{ get { return Physics2D.OverlapBox(transform.position, new Vector2(2, 2), 0, LayerMask.GetMask("RealPlayer")); } }
    Transform brain;
    
    //---------------------------------//


    PlayerControler player;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerInRange == true) {
            EnemyAttack();
        }
        


        if (health <= 0)
        {
            Destroy(gameObject);
        }


        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //makes sure the raycast hits the ground layer
        RaycastHit2D raycastGround = Physics2D.Raycast(triggerSideChange.position, Vector2.down, 1, LayerMask.GetMask("Ground"));
        if (raycastGround.collider == false)
        {
            if (isMovingRight == true)
            {
                //this flips the charachter 180 degrees
                transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -0, 0);
                isMovingRight = true;
            }

        }
    }

    public void EnemyAttack()
    {
        animator.SetBool("isAttacking", playerInRange);

        //check if player is in range 
        //if (playerInRange)
        //{
        //    //Collider2D[] playerToOuch = Physics2D.OverlapCircleAll(positionOfAttack.position, attackRange, playerMask);
        //    //for (int i = 0; i < playerToOuch.Length; i++)
        //    //{
        //    //    playerToOuch[i].GetComponent<PlayerControler>().PlayerTakeDamage(damage);
        //    //}
        //}
        //else {
        //    animator.SetBool("isAttacking", false);
        //}
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControler player = collision.gameObject.GetComponent<PlayerControler>();
            player.PlayerTakeDamage(damage);
        }
        Debug.Log("player took " + damage + "amount of damage");
    }


    public void EnemyTakeDamage(int damage)
    {
        animator.SetTrigger("takeDamage");
        health -= damage;
        Debug.Log("Damage Taken");
    }
}
