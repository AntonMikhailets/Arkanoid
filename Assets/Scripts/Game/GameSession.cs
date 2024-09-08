using System;
using Blocks;
using DefaultNamespace;
using UIManagement.Core;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private const int StartLevelValue = 0;
    private const int StartAttemptsValue = 3;

    private const string StartNode = "Start";
    private const string WinNode = "Win";
    private const string LoseNode = "Lose";
    
    public event Action<int> AttemptsChanged;
    public event Action<int> LevelChanged;
    
    [SerializeField] private InformationScreen _startScreen;
    [SerializeField] private InformationScreen _victoryScreen;
    [SerializeField] private InformationScreen _looseScreen;
    
    [SerializeField] private BallFallingController _fallingController;
    [SerializeField] private BlocksController _blocksController;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private GamePause _gamePause;

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

        if (Attempts <= 0) {
            ShowLoseScreen();
        } else {
            RestartLevel();
        }
    }

    private void OnAllBlocksDestroyed()
    {
        ShowVictoryScreen();
    }

    private void RestartLevel()
    {
        _levelManager.Restart();
    }

    private void ShowStartScreen()
    {
        UIManager.Instance.ShowViewNode(StartNode);
    }

    private void ShowVictoryScreen()
    {
        _gamePause.Pause();
        UIManager.Instance.ShowViewNode(WinNode);
        _victoryScreen.Show(UpgradeLevel);
    }

    private void ShowLoseScreen()
    {
        UIManager.Instance.ShowViewNode(LoseNode);
        _looseScreen.Show(RestartGame);
    }

    private void UpgradeLevel()
    {
        _gamePause.Play();
        _levelManager.LoadLevel(++Level);
    }

    private void RestartGame()
    {
        _gamePause.Play();
        Level = StartLevelValue;
        Attempts = StartAttemptsValue;
        _levelManager.LoadLevel(StartLevelValue);
    }
}
