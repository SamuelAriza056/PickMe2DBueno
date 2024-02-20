using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Inicio del singleton b�sico
    private static GameManager instance;
    public static GameManager Instance
    {
        get 
        { 
            if (instance == null)
            {
                Debug.Log("GAme MAnager is Null");
            }

            return instance;
        }
    }
    //Fin del singleton b�sico, se referencia en el awake

    //Variables
    private void Awake()
    {
        instance = this;
    }
    
}
