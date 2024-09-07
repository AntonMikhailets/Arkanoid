using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelConfig _config;
    [SerializeField] private Transform _blocksPosition;

    private BlocksController _currentBlocksController;
    
    public void LoadLevel(int value)
    {
        
    }

    private void InstantiateBlocks()
    {
        
    }
}
