using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    private const string BallTag = "Ball";

    public event Action BlockDestroyed;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag(BallTag))
        {
            BlockDestroyed?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
