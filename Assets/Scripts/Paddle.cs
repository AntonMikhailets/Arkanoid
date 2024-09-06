using UnityEngine;

public class Paddle : MonoBehaviour
{
    private const  string Axis = "Horizontal";
    
    [SerializeField] private float _speed = 10f;

    private void Update()
    {
        var moveVector = Input.GetAxis(Axis) * _speed * Time.deltaTime;
        transform.position += new Vector3(moveVector, 0, 0);
    }
}
