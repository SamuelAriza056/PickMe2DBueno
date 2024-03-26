using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueGolem : MonoBehaviour
{
    public Animator anim;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemigo golpea");
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.PerderVidas();
            
        }
    }
}
