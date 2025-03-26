using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _uiFeedbackText;

    private void ShowChestOpenUI()
    {
        if (_uiFeedbackText != null)
        {
            _uiFeedbackText.text = "Chest Opened!";
        }
    }

    private void ShowChestLockedUI()
    {
        if (_uiFeedbackText != null)
        {
            _uiFeedbackText.text = "Find the key first!";
        }
    }

    private void ShowKeyPickUpUI()
    {
        if (_uiFeedbackText != null)
        {
            _uiFeedbackText.text = "Key Acquired!";
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        if (_uiFeedbackText == null)
        {
            Debug.LogError("Need UI Ref");
            return;
        }
        
        EventManager.SubscribeToUIEvents(EventManager.UIEvent.ChestOpenEvent, ShowChestOpenUI);
        EventManager.SubscribeToUIEvents(EventManager.UIEvent.ChestLockedEvent, ShowChestLockedUI);
        EventManager.SubscribeToUIEvents(EventManager.UIEvent.KeyPickUpEvent, ShowKeyPickUpUI);
    }

    void OnDisable()
    {
        if (_uiFeedbackText == null)
        {
            Debug.LogError("Need UI Ref");
            return;
        }
        
        EventManager.UnsubscribeToUIEvents(EventManager.UIEvent.ChestOpenEvent, ShowChestOpenUI);
        EventManager.UnsubscribeToUIEvents(EventManager.UIEvent.ChestLockedEvent, ShowChestLockedUI);
        EventManager.UnsubscribeToUIEvents(EventManager.UIEvent.KeyPickUpEvent, ShowKeyPickUpUI);
    }
}
