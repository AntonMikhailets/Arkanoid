using System;
using Blocks;
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
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private GamePause _gamePause;

    private int _attempts;
    private int _level;
    private bool _isPause;

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
        Level = 0;
        _levelManager.LoadLevel(Level);

        ShowStartScreen();
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
        UIManager.Instance.ShowViewNode("Start");
    }

    private void ShowVictoryScreen()
    {
        _gamePause.Pause();
        UIManager.Instance.ShowViewNode("Win");
        _victoryScreen.Show(UpgradeLevel);
    }

    private void ShowLoseScreen()
    {
        UIManager.Instance.ShowViewNode("Lose");
        _looseScreen.Show();
    }

    private void UpgradeLevel()
    {
        _levelManager.LoadLevel(++Level);
        _gamePause.Play();
    }
}
