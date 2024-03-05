using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem2D : MonoBehaviour
{
    public int direction;
    public Animator anim;
    public GameObject target;
    public bool atacando;
    public float rangoVision;
    public float rangoAtaque;
    public GameObject rango;
    public GameObject hit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Comportamientos()
    {
        if (atacando)
        {
            if (transform.position.x < target.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            anim.SetBool("Walk", false);
        }
    }

    public void Final_Anim()
    {
        anim.SetBool("Attack", true);
        atacando = true;
        rango.GetComponent<BoxCollider2D>().enabled = atacando; 
    }
    public void ColliderWeaponTrue()
    {
        hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        hit.GetComponent <BoxCollider2D>().enabled = false;
    }
}
