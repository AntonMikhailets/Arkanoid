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
        Disable();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isActive)
        {
            ActivateBall();
        }
    }

    public void Disable()
    {
        _isActive = false;
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void ActivateBall()
    {
        _isActive = true;
        transform.SetParent(_activeParent);
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody.AddForce(_initialVelocity);
    }
}
