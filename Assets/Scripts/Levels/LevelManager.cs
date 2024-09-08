using Blocks;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelConfig _config;
    [SerializeField] private BlocksController _blocksController;
    [SerializeField] private GameInitializer _gameInitializer;

    public void LoadLevel(int value)
    {
        Debug.Log($"LevelManager.LoadLevel: {value}");
        
        var levelConfig = _config.BlocksConfiguration[value];
        _blocksController.SetupGroup(levelConfig);
        Restart();
    }

    public void Restart()
    {
        _gameInitializer.InitializeBall();
    }
}
