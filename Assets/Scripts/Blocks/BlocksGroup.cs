using System;
using UnityEngine;

public class BlocksGroup : MonoBehaviour
{
    public event Action AllBlocksDestroyed;
    public event Action BlockDestroyed;
    
    [SerializeField] private Block[] _blocks;
    [SerializeField] private int _blocksAmount;
    
    private void Start()
    {
        _blocksAmount = _blocks.Length;

        foreach (var block in _blocks)
        {
            block.BlockDestroyed += OnBlockDestroyed;
        }
    }

    private void OnDestroy()
    {
        foreach (var block in _blocks)
        {
            block.BlockDestroyed -= OnBlockDestroyed;
        }
    }

    private void OnBlockDestroyed()
    {
        _blocksAmount--;
        BlockDestroyed?.Invoke();

        if (_blocksAmount == 0)
        {
            AllBlocksDestroyed?.Invoke();
        }
    }
}
