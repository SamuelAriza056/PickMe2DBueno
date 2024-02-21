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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
