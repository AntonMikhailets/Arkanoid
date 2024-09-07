using System;
using DefaultNamespace;
using UIManagement.Core;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private const int StartAttemptsValue = 3;
    
    public event Action<int> AttemptsChanged;
    public event Action<int> LevelChanged;
    
    [SerializeField] private InformationScreen _startScreen;
    [SerializeField] private InformationScreen _victoryScreen;
    [SerializeField] private InformationScreen _looseScreen;
    
    [SerializeField] private BallFallingController _fallingController;
    [SerializeField] private GameInitializer _gameInitializer;
    [SerializeField] private BlocksController _blocksController;

    private int _attempts;
    private int _level;

    public int Attempts
    {
        get => _attempts;
        private set
        {
            _attempts = value;
            AttemptsChanged?.Invoke(value);
        }
    }
    
    private int Level
    {
        get => _level;
        set
        {
            _level = value;
            LevelChanged?.Invoke(value);
        }
    }
    
    private void Awake()
    {
        _fallingController.BallFell += OnBallFell;
        _blocksController.AllBlocksDestroyed += OnAllBlocksDestroyed;
    }

    private void Start()
    {
        Attempts = StartAttemptsValue;
        UIManager.Instance.ShowViewNode("Start");
    }

    private void OnDestroy()
    {
        _fallingController.BallFell -= OnBallFell;
        _blocksController.AllBlocksDestroyed -= OnAllBlocksDestroyed;
    }

    private void OnBallFell()
    {
        Attempts--;

        if (Attempts <= 0)
        {
            ShowLoseScreen();
        }
        else
        {
            RestartLevel();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0; 
    }
    
    private void Play()
    {
        Time.timeScale = 1; 
    }
    
    private void OnAllBlocksDestroyed()
    {
        ShowVictoryScreen();
    }

    private void RestartLevel()
    {
        _gameInitializer.InitializeBall();
    }

    private void ShowStartScreen()
    {
       
    }

    private void ShowVictoryScreen()
    {
        Pause();
        UIManager.Instance.ShowViewNode("Win");
        _victoryScreen.Show();
    }

    private void ShowLoseScreen()
    {
        _looseScreen.Show();
    }
}
