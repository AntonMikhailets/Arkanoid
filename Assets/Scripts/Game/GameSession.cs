using System;
using Blocks;
using Gameplay;
using Levels;
using UI;
using UnityEngine;

namespace Game
{
    public class GameSession : MonoBehaviour
    {
        private const int GameInitialValue = 0;

        public event Action<int> AttemptsChanged;
        public event Action<int> LevelChanged;
        public event Action<int> ScoreChanged;

        [SerializeField] private GameConfig _config;
        [SerializeField] private ScreenManager _screenManager;
        [SerializeField] private BallFallingController _fallingController;
        [SerializeField] private BlocksController _blocksController;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private GamePause _gamePause;

        private int _attempts;
        private int _level;
        private int _score;

        private int Attempts
        {
            get => _attempts;
            set
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
    
        private int Score
        {
            get => _score;
            set
            {
                _score = value;
                ScoreChanged?.Invoke(value);
            }
        }
    
        private void Awake()
        {
            _fallingController.BallFell += OnBallFell;
            _blocksController.AllBlocksDestroyed += OnAllBlocksDestroyed;
            _blocksController.BlockDestroyed += OnBlocksDestroyed;
        
            InitScreens();
        }

        private void Start()
        {
            RestartGame();
            StartGame();
        }

        private void OnDestroy()
        {
            _fallingController.BallFell -= OnBallFell;
            _blocksController.AllBlocksDestroyed -= OnAllBlocksDestroyed;
            _blocksController.BlockDestroyed -= OnBlocksDestroyed;
        }
    
        public void RestartGame()
        {
            _gamePause.Play();
            Level = GameInitialValue;
            Attempts = _config.GameAttempts;
            Score = GameInitialValue;
            _levelManager.LoadLevel(GameInitialValue);
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
            CompleteLevel();
        }
    
        private void OnBlocksDestroyed()
        {
            Score += _config.BlockDestructionReward;
        }
    
        private void InitScreens()
        {
            _screenManager.SetStartScreenAction(_gamePause.Play);
            _screenManager.SetLevelCompleteScreenAction(UpgradeLevel);
            _screenManager.SetGameLoseScreenAction(RestartGame);
            _screenManager.SetGameCompleteScreenAction(RestartGame);
        }

        private void RestartLevel()
        {
            _levelManager.Restart();
        }

        private void StartGame()
        {
            _screenManager.ShowStartScreen();
        }

        private void ShowLoseScreen()
        {
            _screenManager.ShowGameLoseScreen();
        }
    
        private void ShowGameCompleteScreen()
        {
            _screenManager.ShowGameCompleteScreen();
        }

        private void CompleteLevel()
        {
            if (Level == _config.LevelsAmount - 1)
            {
                ShowGameCompleteScreen();
            } else {
                _screenManager.ShowLevelCompleteScreen();
            }
        }

        private void UpgradeLevel()
        {
            _gamePause.Play();
            ++Level;
            _levelManager.LoadLevel(Level);
        }
    }
}
