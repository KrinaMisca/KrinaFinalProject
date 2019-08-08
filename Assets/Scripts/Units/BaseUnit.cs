using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{

    #region VARIABLES
    public bool isAlive;
    public int activeWeaponIndex;
    #endregion

    #region UNIT STATS
    [Header("Unit Stats:")]

    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [SerializeField] protected int speed;
    //might need to use this 
    [SerializeField] protected LayerMask hitableLayer;
    [HideInInspector] public float speedMultiplier = 1;
    #endregion


    [HideInInspector] public Rigidbody2D rb;
    protected Animator anim;
    protected Vector3 scale;
    private bool facingRight = true;

    virtual public void Init()
    {

        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        //tr = GetComponent<TrailRenderer>();
        anim = GetComponent<Animator>();

      
    }

    virtual public void UnitUpdate(float dt, Vector2 dir)
    {
       
    }

    virtual public void UnitFixedUpdate()
    {
      
    }

    virtual public void Death()
    {
        Debug.Log("basic isDead");
        isAlive = false;
        anim.SetTrigger("isDead");
    }

    virtual public void MovementAnimations()
    {

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    //public void UseWeapon(Vector2 dir)
    //{

    //    weaponList[activeWeaponIndex].Attack(dir, this.transform.position);
    //}

    //virtual public void UpdateMovement(Vector2 dir)
    //{
    //    if (!isDashing)
    //    {
    //        rb.velocity = dir * speed * speedMultiplier;
    //        anim.SetFloat("RunSpeed", rb.velocity.magnitude / speed);
    //    }
    //    else
    //        DashUpdate(dir);
    //}

    public void ChangeSpeedMultiplier(float _speedMult)
    {
        speedMultiplier = _speedMult;

    }

    public virtual void TakeDamage(float dmg)
    {
        
    }

    public void UseAttackAnim(string triggerName)
    {
        anim.SetTrigger(triggerName);
    }

}
