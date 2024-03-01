using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("General UI References")]
    [SerializeField] GameObject WinPanel;

    [Header("Text References")]
    [SerializeField] TMP_Text winText;
    // Start is called before the first frame update
    void Start()
    {
        WinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
