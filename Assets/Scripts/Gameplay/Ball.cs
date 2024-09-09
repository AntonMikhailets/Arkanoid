using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform _activeParent;
    [SerializeField] private GamePause _pause;

    private Rigidbody2D _rigidbody;
    private bool _isActive;
    private Vector2 _velocityBeforePause;
    private float _pushingVelocity;

    public Rigidbody2D Rigidbody => _rigidbody;
    public bool IsActive => _isActive;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _pause.GamePaused += OnGamePaused;
        _pause.GamePlayed += OnGamePlayed;
        Disable();
    }

    private void OnDestroy()
    {
        _pause.GamePaused -= OnGamePaused;
        _pause.GamePlayed -= OnGamePlayed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isActive)
        {
            PushBall();
        }
    }

    public void Disable()
    {
        _isActive = false;
        _rigidbody.velocity = Vector2.zero;
    }

    public void SetStartVelocity(float value)
    {
        _pushingVelocity = value;
    }

    private void OnGamePaused()
    {
        _velocityBeforePause = _rigidbody.velocity;
        Disable();
    }

    private void OnGamePlayed()
    {
        _isActive = true;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.velocity = _velocityBeforePause;
    }

    private void PushBall()
    {
        _isActive = true;
        transform.SetParent(_activeParent);
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(Vector2.up * _pushingVelocity);
    }
}
