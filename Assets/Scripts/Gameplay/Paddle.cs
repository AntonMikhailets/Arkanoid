using Game;
using UnityEngine;

namespace Gameplay
{
    public class Paddle : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const float HalfPaddleSize = 250f;
        private const int Degrees45 = 45;
        private const int Zero = 0;

        [SerializeField] private RectTransform _rect;
        [SerializeField] private RectTransform _canvasRect;
        [SerializeField] private GamePause _pause;
        [SerializeField] private float _speed = 10f;

        private float ScreenWidth => _canvasRect.sizeDelta.x;
        private float PaddleWidth => _rect.sizeDelta.x;
        private float LeftBorder => -ScreenWidth / 2 + PaddleWidth / 2;
        private float RightBorder => ScreenWidth / 2 - PaddleWidth / 2;

        public void TakeInitialPosition()
        {
            _rect.localPosition = new Vector3(Zero, _rect.localPosition.y, Zero);
        }

        private void FixedUpdate()
        {
            if (_pause.IsPause)
            {
                return;
            }
        
            var moveInput = Input.GetAxis(Horizontal);
            var newPosition = _rect.localPosition + new Vector3(moveInput * _speed * Time.deltaTime, 0, 0);

            newPosition.x = Mathf.Clamp(newPosition.x, LeftBorder, RightBorder);
            _rect.localPosition = newPosition;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent<Ball>(out var ball))
            {
                PushBall(ball);
            }
        }

        private void PushBall(Ball ball)
        {
            if(!ball.IsActive) return;
        
            var ballRb = ball.Rigidbody;
            var offset = (ball.transform.position.x - transform.position.x) / -HalfPaddleSize;
            var angle = offset * Degrees45;
            var newDirection = Quaternion.Euler(0, 0, angle) * Vector2.up;

            ballRb.velocity = newDirection.normalized * ballRb.velocity.magnitude;
        }
    }
}
