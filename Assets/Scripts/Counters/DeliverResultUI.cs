using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System;

public class DeliverResultUI : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color succesColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite succesSprite;
    [SerializeField] private Sprite failedSprite;

    private Animator animator;
    private const string    ANIM_KEY = "Popup";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        DeliveryManager.Instance.OnRecipeSucces += DeliveryManager_OnRecipeSucces;

        gameObject.SetActive(false);
    }

    private void DeliveryManager_OnRecipeSucces(object sender, EventArgs e)
    {
        gameObject.SetActive(true);

        animator.SetTrigger(ANIM_KEY);

        backgroundImage.color = succesColor;
        iconImage.sprite = succesSprite;
        messageText.text = "Отлично!";
    }

    private void DeliveryManager_OnRecipeFailed(object sender, EventArgs e)
    {
        gameObject.SetActive(true);

        animator.SetTrigger(ANIM_KEY);
        
        backgroundImage.color = failedColor;
        iconImage.sprite = failedSprite;
        messageText.text = "Ацтой!";
        
    }
}
