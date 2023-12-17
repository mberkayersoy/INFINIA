using GameSystemsCookbook;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreloadUI : MonoBehaviour
{
    [SerializeField] private Image progressBar;

    [Header("Listen to Event Channels")]
    [Tooltip("Percentage of loading time that is complete")]
    [SerializeField] private FloatEventChannelSO m_LoadProgressUpdated;
    [Tooltip("Is the loading complete?")]
    [SerializeField] private VoidEventChannelSO m_PreloadComplete;

    private void OnEnable()
    {
        m_LoadProgressUpdated.OnEventRaised += UpdateProgressBar;
        m_PreloadComplete.OnEventRaised += Hide;

    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateProgressBar(float fillAmountValue)
    {
        progressBar.fillAmount = fillAmountValue;
    }

    private void OnDisable()
    {
        m_LoadProgressUpdated.OnEventRaised -= UpdateProgressBar;
        m_PreloadComplete.OnEventRaised -= Hide;
        progressBar.fillAmount = 0;
    }

}
