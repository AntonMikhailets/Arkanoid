using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 _initialVelocity;
    [SerializeField] private Transform _activeParent;

    private Rigidbody2D _rigidbody;
    private bool _isActive;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateBall();
        }
    }

    private void ActivateBall()
    {
        transform.SetParent(_activeParent);
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(_initialVelocity);
    }
}
