using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private int _gameAttempts;
        [SerializeField] private int _blockDestructionReward;
        [SerializeField] private float _startBallVelocity;
        [SerializeField] private float _ballForceIncreasingCoefficient;
        
        public LevelConfig LevelConfig => _levelConfig;
        public int GameAttempts => _gameAttempts;
        public int BlockDestructionReward => _blockDestructionReward;
        public float StartBallVelocity => _startBallVelocity;
        public float BallForceIncreasingCoefficient => _ballForceIncreasingCoefficient;

        public int LevelsAmount => _levelConfig.BlocksConfiguration.Length;
    }
}