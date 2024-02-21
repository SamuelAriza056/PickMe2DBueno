using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D golemRB;

    public float velocidadMovimiento;

    public LayerMask capaAbajo;
    public LayerMask capaEnfrente;

    public float distanciaAbajo;
    public float distanciaEnfrente;

    public Transform controladorAbajo;
    public Transform controladorEnfrente;

    public bool informacionAbajo;
    public bool informacionEnfrente;

    private bool mirandoALADerecha = true;

    private void Update()
    {
        golemRB.velocity = new Vector2(velocidadMovimiento, golemRB.velocity.y);

        informacionEnfrente = Physics2D.Raycast(controladorEnfrente.position, transform.right, distanciaEnfrente, capaEnfrente);
        informacionAbajo = Physics2D.Raycast(controladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);

        if (informacionEnfrente || !informacionAbajo)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoALADerecha = !mirandoALADerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidadMovimiento *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorAbajo.transform.position, controladorAbajo.transform.position +transform.up * -1 * distanciaAbajo);
        Gizmos.DrawLine(controladorEnfrente.transform.position, controladorEnfrente.transform.position + transform.right * -1 * distanciaEnfrente);
    }
}
