using System;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public event Action PressedConfirm = delegate { };
    public event Action PressedCancel = delegate { };
    public event Action PressedLeft = delegate { };
    public event Action PressedRight = delegate { };
    public Button _playCardButton;

    private void Awake()
    {
        _playCardButton.onClick.AddListener(EndTurn);
    }
    private void Update()
    {
        DetectConfirm();
        DetectCancel();
        DetectLeft();
        DetectRight();

    }

    private void EndTurn()
    {
        PressedConfirm?.Invoke();
    }

    private void DetectRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PressedRight?.Invoke();
        }
    }
    private void DetectLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PressedLeft?.Invoke();

        }
    }
    private void DetectCancel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PressedCancel?.Invoke();
        }
    }
    private void DetectConfirm()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PressedConfirm?.Invoke();
        }
    }
}
