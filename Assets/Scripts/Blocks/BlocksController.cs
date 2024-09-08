using System;
using UnityEngine;

namespace Blocks
{
    public class BlocksController : MonoBehaviour
    {
        public event Action AllBlocksDestroyed;
        public event Action BlockDestroyed;
        
        private BlocksGroup _currentGroup;

        private void OnDestroy()
        {
            UnsubscribeToEvents();
        }

        public void SetupGroup(BlocksGroup blocksGroup)
        {
            UnsubscribeToEvents();
            DeleteCurrentGroup();
            
            _currentGroup = InstantiateBlocks(blocksGroup.gameObject);
            _currentGroup.AllBlocksDestroyed += OnAllBlocksDestroyed;
            _currentGroup.BlockDestroyed += OnBlockDestroyed;
        }

        private void UnsubscribeToEvents()
        {
            if (_currentGroup != null) {
                _currentGroup.AllBlocksDestroyed -= OnAllBlocksDestroyed;
                _currentGroup.BlockDestroyed -= OnBlockDestroyed;
            }
        }

        private void OnAllBlocksDestroyed()
        {
            AllBlocksDestroyed?.Invoke();
        }
        
        private void OnBlockDestroyed()
        {
            BlockDestroyed?.Invoke();
        }

        private void DeleteCurrentGroup()
        {
            if (_currentGroup != null)
            {
                Destroy(_currentGroup.gameObject);
            }
        }
        
        private BlocksGroup InstantiateBlocks(GameObject obj)
        {
            return Instantiate(obj, transform.position, transform.rotation, transform).GetComponent<BlocksGroup>();
        }
    }
}