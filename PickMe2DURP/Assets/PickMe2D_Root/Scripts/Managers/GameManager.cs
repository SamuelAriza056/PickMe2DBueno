using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Inicio del singleton básico
    private static GameManager instance;
    private static PlayerController playerController;
    public static GameManager Instance
    {
        get 
        { 
            if (instance == null)
            {
                Debug.Log("Game Manager is Null");
            }

            return instance;
        }
    }
    //Fin del singleton básico, se referencia en el awake

    //Variables
    public int points;
    public int winPoints;
    public int sceneToLoad;

    private int vidas = 3;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (points >= winPoints)
        {
            LoadScene(sceneToLoad);
        }
    }

    public void PointsUp(int gain)
    {
        points += gain;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void PerderVidas()
    {
        vidas -= 1;
        playerController.DesactivarVidas(vidas);
    }
    

    
}
