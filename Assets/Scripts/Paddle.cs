using UnityEngine;

public class Paddle : MonoBehaviour
{
    private const  string Horizontal = "Horizontal";

    [SerializeField] private RectTransform _rect;
    [SerializeField] private RectTransform _canvasRect;
    [SerializeField] private float _speed = 10f;

    private float ScreenWidth => _canvasRect.sizeDelta.x;
    private float PaddleWidth => _rect.sizeDelta.x;
    private float LeftBorder => -ScreenWidth / 2 + PaddleWidth / 2;
    private float RightBorder => ScreenWidth / 2 - PaddleWidth / 2;

    private void FixedUpdate()
    {
        var moveInput = Input.GetAxis(Horizontal);
        var newPosition = _rect.localPosition + new Vector3(moveInput * _speed * Time.deltaTime, 0, 0);

        newPosition.x = Mathf.Clamp(newPosition.x, LeftBorder, RightBorder);
        _rect.localPosition = newPosition;
    }
}
