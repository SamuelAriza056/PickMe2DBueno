using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemaScript : MonoBehaviour
{
    public int pointSum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManafer.Instance.PlaySFX(0);
            GameManager.Instance.PointsUp(pointSum);
            gameObject.SetActive(false);
        }
    }
}
