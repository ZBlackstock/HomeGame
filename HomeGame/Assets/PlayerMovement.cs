using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private bool isFacingRight = true;

    [SerializeField]private bool doubleJump;

    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;

    bool isGrounded = false;

    [SerializeField] private TrailRenderer tr;

    [SerializeField] private Animator anim;

    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;
    public Health health;

    public bool isDead;


    private void Update()
    {
        if (isDashing)
        {
            print("Dashin");
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            print("jump 1");
            if (isGrounded || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                isGrounded = false;
                anim.SetBool("isJumping", true);
                doubleJump = !doubleJump;
                print("jump 2");
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f * Time.deltaTime);
        }

        

        if (Input.GetButtonDown("Fire2") && canDash)
        {
            StartCoroutine(Dash());
        }

        if (horizontal >= 0.1f || horizontal <= -0.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else   
        { 
            anim.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isAttacking",true);
        }

        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        anim.SetBool("isJumping", !isGrounded);

        if (collision.CompareTag("spike"))
        {
            anim.SetTrigger("Attacked");
        }
    }

    public void die()
    {

    }
    public void attack()
        {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

            foreach (Collider2D enemyGameObject in enemy)
            {
                Debug.Log("hit enemy");
                enemyGameObject.GetComponent<enemyHealth>().health -= damage;
            }
        }

    public void endAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("yVelocity", rb.velocity.y);

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        anim.SetBool("isDashing", true);
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        anim.SetBool("isDashing", false);
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
