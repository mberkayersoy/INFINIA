using GameSystemsCookbook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnMenuButton : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _returnMenu;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(() => _returnMenu.RaiseEvent());
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
