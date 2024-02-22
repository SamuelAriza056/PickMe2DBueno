using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManafer : MonoBehaviour
{
    //Declaracion de singuelto
    public static AudioManafer Instance;

    [Header("Audio Source References")]
    [SerializeField] AudioSource musicSource;
    [SerializeField]AudioSource sfxSource;

    [Header("Audio Clip Array")]
    public AudioClip[] musicList;
    public AudioClip[] sfxList;

    private void Awake()
    { 
        //Singelton que no se destruye entre escenas

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int musicIndex)
    {
        musicSource.clip = musicList[musicIndex];
        musicSource.Play();
    }
    public void PlaySFX (int sfxIndex)
    {
        sfxSource.PlayOneShot(sfxList[sfxIndex]);
    }

}
