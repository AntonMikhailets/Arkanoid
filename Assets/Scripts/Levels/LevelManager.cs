using Blocks;
using Levels;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private BlocksController _blocksController;
    [SerializeField] private BallInitializer _ballInitializer;
    
    private int _currentLevel;

    private LevelConfig _levelConfig => _gameConfig.LevelConfig; 

    public void LoadLevel(int value)
    {
        _currentLevel = value;
        Debug.Log($"LevelManager.LoadLevel: {_currentLevel}");
        
        var levelConfig = _levelConfig.BlocksConfiguration[_currentLevel];
        _blocksController.SetupGroup(levelConfig);
        Restart();
    }

    public void Restart()
    {
        var forceIncreasing = _gameConfig.BallForceIncreasingCoefficient * _currentLevel;
        var initialBallForce = _gameConfig.StartBallVelocity + forceIncreasing;
        _ballInitializer.InitializeBall(initialBallForce);   
    }
}
