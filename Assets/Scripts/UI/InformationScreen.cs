using System;
using UnityEngine;
using UnityEngine.UI;

public class InformationScreen : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    private Action _clickAction;

    public void Show(Action clickAction = null)
    {
        _clickAction = clickAction;
        _actionButton.onClick.AddListener(InvokeClickAction);
    }

    private void InvokeClickAction()
    {
        if (_clickAction != null && !Input.GetKeyDown(KeyCode.Space))
        {
            _clickAction?.Invoke();
        }
    }
}
