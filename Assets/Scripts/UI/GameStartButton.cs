using GameSystemsCookbook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    [Header("Broadcast")]
    [SerializeField] private VoidEventChannelSO _gameStart;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => _gameStart.RaiseEvent());
    }
}
