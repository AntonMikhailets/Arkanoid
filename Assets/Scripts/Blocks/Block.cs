using System;
using DG.Tweening;
using UnityEngine;

namespace Blocks
{
    public class Block : MonoBehaviour
    {
        private const string BallTag = "Ball";
        private const float Duration = 0.2f;

        public event Action BlockDestroyed;
    
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.CompareTag(BallTag))
            {
                BlockDestroyed?.Invoke();
                Fade();
            }
        }
    
        private void Fade()
        {
            transform.DOScale(Vector3.zero, Duration)
                .SetEase(Ease.OutBack)
                .OnComplete(() => gameObject.SetActive(false));
        }
    }
}
