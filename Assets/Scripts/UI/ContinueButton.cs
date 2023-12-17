using GameSystemsCookbook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private BoolEventChannelSO _pauseGame;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => _pauseGame.RaiseEvent(false));
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
