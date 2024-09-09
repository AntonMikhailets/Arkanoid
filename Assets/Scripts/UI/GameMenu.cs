using Game;
using UIManagement.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameMenu : MonoBehaviour
    {
        private const string MenuNode = "Pause";
        
        [SerializeField] private GamePause _gamePause;
        [SerializeField] private GameSession _gameSession;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
            _continueButton.onClick.AddListener(OnContinueButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _quitButton.onClick.AddListener(OnQuitButtonClicked);
        }
        
        private void OnPauseButtonClicked()
        {
            if (!_gamePause.IsPause && !Input.GetKeyDown(KeyCode.Space))
            {
                _gamePause.Pause();
                UIManager.Instance.ShowViewNode(MenuNode);
            }
        }

        private void OnContinueButtonClicked()
        {
            _gamePause.Play();
        }
        
        private void OnRestartButtonClicked()
        {
            _gameSession.RestartGame();
        }

        private void OnQuitButtonClicked()
        {
            Application.Quit();
        }
    }
}
