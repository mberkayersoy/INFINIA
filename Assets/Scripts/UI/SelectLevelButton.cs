using GameSystemsCookbook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelButton : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _selectLevelPanell;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => _selectLevelPanell.RaiseEvent());
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
