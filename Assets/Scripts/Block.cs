using UnityEngine;

public class Block : MonoBehaviour
{
    private const string BallTag = "Ball";
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag(BallTag))
        {
            Destroy(gameObject);
        }
    }
}
