using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _exitApplication;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => _exitApplication.RaiseEvent());
    }
}
