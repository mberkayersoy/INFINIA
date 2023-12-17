using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _backButtonEvent;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => _backButtonEvent.OnEventRaised());
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
