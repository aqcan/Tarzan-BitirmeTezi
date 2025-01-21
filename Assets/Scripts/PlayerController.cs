using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    Rigidbody2D rb;

    bool facingRight = true;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float groundCheckRadius = 0.5f;

    bool isJumping;
    bool isGrounded;

    Animator anim;

    public int coin;

    public TextMeshProUGUI text;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
    }

    private void Update()
    {

        text.text = coin.ToString();

        float moveInput = Input.GetAxis("Horizontal"); //sag 1 sol -1

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

        if (isGrounded && isJumping)
        {
            isJumping= false;
        }

        if (moveInput == 0)
        {
            anim.SetBool("hareket", false);
        }
        else
        {
            anim.SetBool("hareket", true);
        }

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }


    }
}
