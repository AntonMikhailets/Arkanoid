using Blocks;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelConfig _config;
    [SerializeField] private BlocksController _blocksController;

    private GameObject _currentBlocksController;
    
    public void LoadLevel(int value)
    {
        _blocksController.SetupGroup(_config.BlocksConfiguration[value]);
    }
}
