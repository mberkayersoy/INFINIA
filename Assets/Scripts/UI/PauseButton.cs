using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private BoolEventChannelSO _pauseGame;
    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => _pauseGame.RaiseEvent(true));
    }
    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
