using TMPro;
using UnityEngine;

public class TopPanel : MonoBehaviour
{
    private const string AttemptsTextFormat = "Hp: {0}";
    private const string LevelTextFormat = "Lvl: {0}";
    private const string ScoreTextFormat = "Score: {0}";
    private const int One = 1;
    
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private TextMeshProUGUI _attemptsText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _gameSession.AttemptsChanged += OnAttemptsChanged;
        _gameSession.LevelChanged += OnLevelChanged;
        _gameSession.ScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        _gameSession.AttemptsChanged -= OnAttemptsChanged;
        _gameSession.LevelChanged -= OnLevelChanged;
        _gameSession.ScoreChanged -= OnScoreChanged;
    }

    private void OnAttemptsChanged(int value)
    {
        _attemptsText.text = string.Format(AttemptsTextFormat, value);
    }

    private void OnLevelChanged(int value)
    {
        _levelText.text = string.Format(LevelTextFormat, value + One);
    }
    
    private void OnScoreChanged(int value)
    {
        _scoreText.text = string.Format(ScoreTextFormat, value);
    }
}
