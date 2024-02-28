using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables de referencia
    private Rigidbody2D playerRB;
    private Animator anim;
    private float horizontalInput;

    //Variables de estadisticas del player
    public float speed;
    public float jumpForce;
    private bool isFacingRight = true;

    [SerializeField] bool isGrounded;
    [SerializeField] GameObject GroundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] int vida;
    [SerializeField] int maxVida = 5;
    [SerializeField] int minVida = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, 0.1f, groundLayer);
        Movement();
        Jump();
        Attack();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(horizontalInput * speed, playerRB.velocity.y);

        //Flip: Si el valor del input es diferente de 0
        if (horizontalInput > 0)
        {
            anim.SetBool("Walk", true);            
            if (!isFacingRight)
            {
                Flip();
            }
        }
        if (horizontalInput < 0)
        {
            anim.SetBool("Walk", true);          
            if (isFacingRight)
            {
                Flip();
            }
        }
        if (horizontalInput == 0)
        {
            anim.SetBool("Walk", false);
            
        }
    }

    void Jump()
    {
        anim.SetBool("Jump", !isGrounded);       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Attack");
        }
    }

    void Vida()
    {
        vida = 5;
        
        if (vida == maxVida)
        {
            maxVida = vida;
        }
        if (vida == minVida)
        {
            
        }
    }
}
