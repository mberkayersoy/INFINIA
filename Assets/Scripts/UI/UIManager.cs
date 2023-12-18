using UnityEngine;
using GameSystemsCookbook;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [Header("Broadcast on Event Channels")]
    [Tooltip("Update the loading progress value (percentage)")]
    [SerializeField] private FloatEventChannelSO _loadProgressUpdated;
    [Tooltip("Notify listeners that preloading has finished.")]
    [SerializeField] private VoidEventChannelSO _preloadComplete;

    [Header("Listen to Event Channels")]
    [SerializeField] private VoidEventChannelSO _gameStart;
    [SerializeField] private BoolEventChannelSO _gamePause;
    [SerializeField] private VoidEventChannelSO _returnMenu;
    [SerializeField] private VoidEventChannelSO _playersReady;
    [SerializeField] private VoidEventChannelSO _backButton;
    [SerializeField] private VoidEventChannelSO _optionsButton;
    [SerializeField] private VoidEventChannelSO _selectLevelButton;
    [SerializeField] private VoidEventChannelSO _exitApplication;
    [SerializeField] private PlayerIDEventChannelSO _playerWonDisplay;
    [SerializeField] private List<PlayerIDSO> playerList;

    [Header("Panels")]
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _selectLevelPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _preloadPanel;
    [SerializeField] private GameObject _levelEndUI;

    [Header("Settings")]
    [SerializeField] private float _preloadDelay = 2f;

    private void OnEnable()
    {
        _gameStart.OnEventRaised += ActivateGamePanel;
        _gamePause.OnEventRaised += PauseGameState;
        _returnMenu.OnEventRaised += ReturnMenuPanel;
        _playersReady.OnEventRaised += CheckPlayersReady;
        _optionsButton.OnEventRaised += ShowOptionsPanel;
        _exitApplication.OnEventRaised += ExitApplication;
        _playerWonDisplay.OnEventRaised += ShowWinner;
    }

    private void OnDisable()
    {
        _gameStart.OnEventRaised -= ActivateGamePanel;
        _gamePause.OnEventRaised -= PauseGameState;
        _returnMenu.OnEventRaised -= ReturnMenuPanel;
        _playersReady.OnEventRaised -= CheckPlayersReady;
        _exitApplication.OnEventRaised -= ExitApplication;
        _playerWonDisplay.OnEventRaised -= ShowWinner;
        StopAllCoroutines();
    }
    private void ShowOptionsPanel()
    {
        SetActivePanel(_optionsPanel.name);
    }

    private void CheckPlayersReady()
    {
        foreach (PlayerIDSO player in playerList)
        {
            if (!player.isReady)
            {
                return;
            }
        }
        DelaySplashScreen(_preloadDelay);
    }

    private void ReturnMenuPanel()
    {
        PauseGameState(false);
        SetActivePanel(_menuPanel.name);
        SceneManager.LoadScene(0);
    }

    private void PauseGameState(bool isPaused)
    {
        _pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0.0f : 1.0f;
    }

    private void ActivateGamePanel()
    {
        SetActivePanel(_gamePanel.name);
    }

    private void SetActivePanel(string activatePanel)
    {
        _menuPanel.SetActive(activatePanel.Equals(_menuPanel.name));
        _gamePanel.SetActive(activatePanel.Equals(_gamePanel.name));
        _selectLevelPanel.SetActive(activatePanel.Equals(_selectLevelPanel.name));
        _optionsPanel.SetActive(activatePanel.Equals(_optionsPanel.name));
        _preloadPanel.SetActive(activatePanel.Equals(_preloadPanel.name));
        _levelEndUI.SetActive(activatePanel.Equals(_levelEndUI.name));
    }

    private void DelaySplashScreen(float delay)
    {
        StartCoroutine(WaitForSplashScreen(delay));
    }

    IEnumerator WaitForSplashScreen(float delay)
    {
        _preloadPanel.SetActive(true);
        float endSplashScreenTime = Time.time + delay;

        while (Time.time < endSplashScreenTime)
        {
            float progress = 100 * (1 - (endSplashScreenTime - Time.time) / delay);
            progress = Mathf.Clamp(progress, 0f, 100f);

            OnLoadProgressUpdated(progress / 100f);

            yield return null;
        }
        _preloadComplete.RaiseEvent();
        OnShowMenuPanel();
    }

    // Raises event channel during splash screen to update progress bar
    private void OnLoadProgressUpdated(float progressValue)
    {
        _loadProgressUpdated.RaiseEvent(progressValue);
    }

    // Signals that preloading is complete
    private void OnShowMenuPanel()
    {
        _preloadComplete.RaiseEvent();
        SetActivePanel(_gamePanel.name);
    }
    private void ShowWinner(PlayerIDSO arg0)
    {
        SetActivePanel(_levelEndUI.name);
    }
    private void ExitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
