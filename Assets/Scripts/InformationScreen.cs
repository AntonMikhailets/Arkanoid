using System;
using UnityEngine;
using UnityEngine.UI;

public class InformationScreen : MonoBehaviour
{
    [SerializeField] private Button _actionButton;

    private Action _clickAction;

    public void Show(Action clickAction = null)
    {
        //gameObject.SetActive(true);
        _clickAction = clickAction;
        _actionButton.onClick.AddListener(InvokeClickAction);
    }

    private void InvokeClickAction()
    {
        if (_clickAction != null)
        {
            _clickAction?.Invoke();
        }
        gameObject.SetActive(false);
    }
}
