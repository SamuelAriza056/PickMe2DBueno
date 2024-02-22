using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] int musicToPlay;
    // Start is called before the first frame update
    void Start()
    {
        AudioManafer.Instance.PlayMusic(musicToPlay);
    }

   
    
}
