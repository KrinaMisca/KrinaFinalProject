using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControler : MonoBehaviour
{
    int health = 3;
    public float jumpForce;
    public float speed;
    private float moveInput;
    private bool facingRight = true;
    private Rigidbody2D rb;
    private Animator animator;

    public HealthBar healthBar;
    float timeLastDmg;

    //PlayerControler player;


    //--------Variables for the jumping mechanics--------//
    bool isGrounded { get { return Physics2D.Raycast(body.position, new Vector2(0, -1), 3, LayerMask.GetMask("Ground")); } }
    public float checkRadius;
    public LayerMask whatIsGround;
    private int numberOfJumps;
    public int maxNumbeOfJumps;
    Transform body;

    //--------------------------------------------------//

    public LayerMask switchLayer;

    //--------------------AttackTest------------------//
    public Transform positionOfAttack;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int damage;

    //------------------------------------------------//
    private void Start()
    {
        numberOfJumps = maxNumbeOfJumps;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        body = transform.Find("Body");
    }

    private void Update()
    {
        // --------- ATTACK TEST --------- //
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {

            Collider2D[] enemiesToOuch = Physics2D.OverlapCircleAll(positionOfAttack.position, attackRange, whatIsEnemy);
            for (int i = 0; i < enemiesToOuch.Length; i++)
            {
                enemiesToOuch[i].GetComponent<EnemyTest>().EnemyTakeDamage(damage);
            }
        }
        // ------------------------------- // 


        // --------- LEVEL SWITCH TEST --------- //
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics2D.OverlapCircleAll(positionOfAttack.position, attackRange, switchLayer);

        }
        // ------------------------------------- //





        // --------------- for the demo Test --------------- //
        if (Input.GetKeyDown(KeyCode.C))
        {
            //HealthBar healthBar = healthBar;
            healthBar.TakeDamage(1);
        }
        // ------------------------------------------------- //

        Debug.Log(Physics2D.Raycast(transform.position, new Vector2(0, -1), 1, LayerMask.GetMask("Ground")).transform?.name);
        if (isGrounded == true)
        {
            numberOfJumps = maxNumbeOfJumps;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && numberOfJumps > 0 || Input.GetKeyDown(KeyCode.W) && numberOfJumps > 0)
        {
            animator.SetTrigger("takeOff");
            rb.velocity = Vector2.up * jumpForce;
            numberOfJumps--;
        }

        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }

    //physics for fixed update
    private void FixedUpdate()
    {
        //--------------------LeftAndRightMovement--------------------//
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        //----------------------------------------------------------//
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        if (!facingRight)
        {
            transform.position = new Vector2(transform.position.x - GetMagicFixNumber(), transform.position.y);
        }
        else if (facingRight)
        {
            transform.position = new Vector2(transform.position.x + GetMagicFixNumber(), transform.position.y);
        }
    }

    private float GetMagicFixNumber()
    {
        return 26.15f;
    }

    public void PlayerTakeDamage(int damage)
    {
        if (Time.time - timeLastDmg > 1)
        {
            timeLastDmg = Time.time;
            health -= damage;
            healthBar.TakeDamage(damage);
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
