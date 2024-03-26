using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public int playerVidas = 5;
    public Image[] vidas;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerVidas = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, 0.1f, groundLayer);
        Movement();
        Jump();
        Attack();
        Muerte();
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

    public void DesactivarVidas(int indice)
    {
        vidas[indice].gameObject.SetActive(false);
    }

    public void ActivarVidas(int indice)
    {
        vidas[indice].gameObject.SetActive(true);
    }

    public void PerderVidas()
    {
        playerVidas -= 1;
        DesactivarVidas(playerVidas);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyAttack"))
        {
            Debug.Log("Has sido golpeado");
            PerderVidas();
        }
    }
    
    private void Muerte()
    {
        if (playerVidas == 0)
        {
            
        }
    }
}
