using System;
using UnityEngine;
using UnityEngine.UI;

public class InformationScreen : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    private Action _currentClickAction;

    public void SetClickAction(Action clickAction)
    {
        _currentClickAction = clickAction;
        _actionButton.onClick.AddListener(InvokeClickAction);
    }

    private void InvokeClickAction()
    {
        if (_currentClickAction != null && !Input.GetKeyDown(KeyCode.Space))
        {
            _currentClickAction?.Invoke();
        }
    }
}
