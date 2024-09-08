using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _ballStartRoot;
    
    public void InitializeBall()
    {
        _ball.Disable();
        _ball.Rigidbody.velocity = Vector2.zero;
        _ball.transform.SetParent(_ballStartRoot);
        _ball.transform.localPosition = Vector3.zero;
    }
}
