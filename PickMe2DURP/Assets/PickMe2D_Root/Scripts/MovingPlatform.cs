using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] int startingPoint; //Numero para determinar el indice del punto de inicio de la plataforma.
    [SerializeField] float speed; //velocidad de plataforma
    [SerializeField] Transform[] points; //Array de puntos de posicion hacia los que la plataforma se movera.
    private int i; //Indice del Array.
    


    // Start is called before the first frame update
    void Start()
    {
        //etear la posicion inicial de la plataforma a uno de los puntos
        //asignando a estarting point un valor numerico.
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f )
            
        {
            i++; //Aumenta en indice, cambia de objetivo
            if (i == points.Length) //Chequea si la plataforma ha llegado al ultimo punto 
            {
                i = 0;// Resetea el indice para que vuelva a empezar
            }

        }

        //Mueve la plataforma a la posicion del punto guardado en el Array en el espacio con valor igual a "i".
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
