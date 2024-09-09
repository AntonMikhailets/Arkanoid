using System;
using UnityEngine;

namespace Blocks
{
    public class BlocksGroup : MonoBehaviour
    {
        public event Action AllBlocksDestroyed;
        public event Action BlockDestroyed;
    
        private Block[] _blocks;
        private int _blocksAmount;
    
        private void Start()
        {
            _blocks = GetComponentsInChildren<Block>();
            _blocksAmount = _blocks.Length;

        
            foreach (var block in _blocks)
            {
                block.BlockDestroyed += OnBlockDestroyed;
            }
        }

        private void OnDestroy()
        {
            if (_blocks == null) return;
        
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
}
