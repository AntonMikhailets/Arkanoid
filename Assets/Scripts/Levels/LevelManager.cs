using Blocks;
using Game;
using Gameplay;
using UnityEngine;

namespace Levels
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private BlocksController _blocksController;
        [SerializeField] private BallInitializer _ballInitializer;
        [SerializeField] private Paddle _paddle;
    
        private int _currentLevel;

        private LevelConfig LevelConfig => _gameConfig.LevelConfig;

        private float InitialForce => _gameConfig.StartBallVelocity + _gameConfig.BallForceIncreasingCoefficient * _currentLevel;

        public void LoadLevel(int value)
        {
            _currentLevel = value;
            Debug.Log($"LevelManager.LoadLevel: {_currentLevel}");
        
            var levelConfig = LevelConfig.BlocksConfiguration[_currentLevel];
            _blocksController.SetupGroup(levelConfig);
            Restart();
        }

        public void Restart()
        {
            _ballInitializer.InitializeBall(InitialForce);
            SetPaddleToDefaultPosition();
        }

        private void SetPaddleToDefaultPosition()
        {
            _paddle.TakeInitialPosition();
        }
    }
}
