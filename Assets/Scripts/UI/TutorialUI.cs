using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private TextMeshProUGUI actionAltText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI gamepadActionText;
    [SerializeField] private TextMeshProUGUI gamepadActionAltText;
    [SerializeField] private TextMeshProUGUI gamepadPauseText;


    private void Start()
    {
        GameInput.Instance.OnBindingRibind += GameInput_OnBindingRibind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        UpdateVisual();

        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRibind(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {  
        moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);

        actionText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Action);
        actionAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Action_Alt);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);

        gamepadActionText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Action);
        gamepadActionAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Action_Alt);
        gamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
