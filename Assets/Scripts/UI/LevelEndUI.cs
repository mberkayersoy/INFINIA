using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameSystemsCookbook;
using System;

public class LevelEndUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winnerText;

    [Header("Listen to Event Channels")]
    [SerializeField] private PlayerIDEventChannelSO _playerWin;

    private void Awake()
    {
        _winnerText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        _playerWin.OnEventRaised += DisplayWinner;
    }

    private void DisplayWinner(PlayerIDSO winner)
    {
        _winnerText.text = winner.playerName + "\n" + "WIN";
    }

    private void OnDisable()
    {
        _playerWin.OnEventRaised -= DisplayWinner;
    }
}