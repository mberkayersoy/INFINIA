using GameSystemsCookbook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerReadyButton : MonoBehaviour
{
    [Header("Broadcast on Event Channels")]
    [SerializeField] private VoidEventChannelSO _playerReady;
    [SerializeField] private PlayerIDSO player;
    private TextMeshProUGUI _buttonText;
    private Button _readyButton;
    private bool _isReady = false;
    private void Awake()
    {
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        _readyButton = GetComponent<Button>();
        player.isReady = false;
        _readyButton.onClick.AddListener(SetButtonDisplay);
    }

    private void SetButtonDisplay()
    {
        _isReady = !_isReady;
        player.isReady = _isReady;
        if (_isReady)
        {
            _buttonText.text = "Ready !";
            _readyButton.image.color = Color.green;
        }
        else
        {
            _buttonText.text = "Ready ?";
            _readyButton.image.color = Color.red;
        }
        _playerReady.RaiseEvent();
    }

    private void OnDisable()
    {
        SetButtonDisplay();
        _readyButton.onClick.RemoveAllListeners();
    }
}
