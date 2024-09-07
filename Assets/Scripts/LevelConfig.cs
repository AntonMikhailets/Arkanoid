using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private BlocksController[] _blocksConfiguration;

    public BlocksController[] BlocksConfiguration => _blocksConfiguration;
}