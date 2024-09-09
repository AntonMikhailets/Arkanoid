using System;
using UnityEngine;

namespace Gameplay
{
    public class BallFallingController : MonoBehaviour
    {
        private const string BallTag = "Ball";

        public event Action BallFell; 
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.CompareTag(BallTag))
            {
                BallFell?.Invoke();
            }
        }
    }
}