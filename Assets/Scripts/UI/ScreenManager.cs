using System;
using Game;
using UIManagement.Core;
using UnityEngine;

namespace UI
{
    public class ScreenManager : MonoBehaviour
    {
        private const string StartNode = "Start";
        private const string WinNode = "Win";
        private const string LoseNode = "Lose";
        private const string CompleteNode = "Complete";
        
        [SerializeField] private InformationScreen _startScreen;
        [SerializeField] private InformationScreen _levelCompleteScreen;
        [SerializeField] private InformationScreen _looseScreen;
        [SerializeField] private InformationScreen _gameCompleteScreen;
        [SerializeField] private GamePause _gamePause;
        
        public void SetStartScreenAction(Action clickAction)
        {
            SetScreenAction(clickAction, _startScreen);
        }
        
        public void SetLevelCompleteScreenAction(Action clickAction)
        {
            SetScreenAction(clickAction, _levelCompleteScreen);
        }

        public void SetGameLoseScreenAction(Action clickAction)
        {
            SetScreenAction(clickAction, _looseScreen);
        }

        public void SetGameCompleteScreenAction(Action clickAction)
        {
            SetScreenAction(clickAction, _gameCompleteScreen);
        }
        
        public void ShowStartScreen()
        {
            ShowScreen(StartNode);
        }
        
        public void ShowLevelCompleteScreen()
        {
            ShowScreen(WinNode);
        }

        public void ShowGameLoseScreen()
        {
            ShowScreen(LoseNode);
        }

        public void ShowGameCompleteScreen()
        {
            ShowScreen(CompleteNode);
        }

        private void SetScreenAction(Action clickAction, InformationScreen screen)
        {
            screen.SetClickAction(clickAction);
        }

        private void ShowScreen(string node)
        {
            _gamePause.Pause();
            UIManager.Instance.ShowViewNode(node);
        }
    }
}