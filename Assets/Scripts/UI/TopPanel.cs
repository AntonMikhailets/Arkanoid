using TMPro;
using UnityEngine;

public class TopPanel : MonoBehaviour
{
    private const string AttemptsTextFormat = "Попыток: {0}";
    private const string LevelTextFormat = "Уроыень: {0}";
    private const int One = 1;
    
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private TextMeshProUGUI _attemptsText;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void Awake()
    {
        _gameSession.AttemptsChanged += OnAttemptsChanged;
        _gameSession.LevelChanged += OnLevelChanged;
    }
    
    private void OnDestroy()
    {
        _gameSession.AttemptsChanged -= OnAttemptsChanged;
        _gameSession.LevelChanged -= OnLevelChanged;
    }

    private void OnAttemptsChanged(int value)
    {
        _attemptsText.text = string.Format(AttemptsTextFormat, value);
    }

    private void OnLevelChanged(int value)
    {
        _levelText.text = string.Format(LevelTextFormat, value + One);
    }
}
