using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _optionsPanel;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => _optionsPanel.RaiseEvent());
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
