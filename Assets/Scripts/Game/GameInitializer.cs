using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _ballStartRoot;
    
    private void Start()
    {
        
    }

    public void InitializeBall()
    {
        _ball.Disable();
        _ball.transform.SetParent(_ballStartRoot);
        _ball.transform.localPosition = Vector3.zero;
    }
}
