using System;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public event Action GamePaused;
    public event Action GamePlayed;
    
    private bool _isPause;

    public bool IsPause => _isPause;

    public void Pause()
    {
        _isPause = true;
        GamePaused?.Invoke();
    }
    
    public void Play()
    {
        _isPause = false;
        GamePlayed?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_isPause)
            {
                Play();
            }
            else
            {
                Pause();
            }
        }
    }
}
