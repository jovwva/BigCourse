using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance;

    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button musicEffectButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectText;
    [SerializeField] private TextMeshProUGUI musicEffectText;

    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button actionButton;
    [SerializeField] private Button actionAltButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button gamepadActionButton;
    [SerializeField] private Button gamepadActionAltButton;
    [SerializeField] private Button gamepadPauseButton;

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
    
    [SerializeField] private Transform rebindPanel;

    private Action OnCloseOptionAction;

    private void Awake()
    {
        Instance = this;

        soundEffectButton.onClick.AddListener(() => {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicEffectButton.onClick.AddListener(() => {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        closeButton.onClick.AddListener(() => {
            Hide();
            OnCloseOptionAction();
        });

        moveUpButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Move_Up);
        });
        moveDownButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Move_Down);
        });
        moveLeftButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Move_Left);
        });
        moveRightButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Move_Right);
        });

        actionButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Action);
        });
        actionAltButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Action_Alt);
        });
        pauseButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Pause);
        });

        gamepadActionButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Gamepad_Action);
        });
        gamepadActionAltButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Gamepad_Action_Alt);
        });
        gamepadPauseButton.onClick.AddListener(() => {
           RebindBinding(GameInput.Binding.Gamepad_Pause);
        });
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        UpdateVisual();
        Hide();
        HideRebindPanel();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectText.text = $"Громкость звуков: {Mathf.Round(SoundManager.Instance.GetVolume() * 10f)}";
        musicEffectText.text = $"Громкость музыки: {Mathf.Round(MusicManager.Instance.GetVolume() * 10f)}";
    
        moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);

        actionText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Action);
        actionAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Action_Alt);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);

        gamepadActionText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Action);
        gamepadActionAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Action_Alt);
        gamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }
    public void Show(Action OnCloseOptionAction)
    {
        this.OnCloseOptionAction = OnCloseOptionAction;
        gameObject.SetActive(true);

        soundEffectButton.Select();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowRebindPanel()
    {
        rebindPanel.gameObject.SetActive(true);
    }
    public void HideRebindPanel()
    {
        rebindPanel.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowRebindPanel();

        GameInput.Instance.RebindBinding(binding, () => {
            HideRebindPanel();
            UpdateVisual();
        });
    }
}
