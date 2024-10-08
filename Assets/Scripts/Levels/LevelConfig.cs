using Blocks;
using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private BlocksGroup[] _blocksConfiguration;

        public BlocksGroup[] BlocksConfiguration => _blocksConfiguration;
    }
}