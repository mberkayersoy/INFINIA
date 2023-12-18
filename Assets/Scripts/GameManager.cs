using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] playerList;
    [SerializeField] private VoidEventChannelSO _preloadComplete;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Camera menuCamera;

    private void OnEnable()
    {
        _preloadComplete.OnEventRaised += StartGame;
    }

    private void StartGame()
    {
        menuCamera.enabled = false;
        foreach (GameObject player in playerList)
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
            player.GetComponentInChildren<Rigidbody>().useGravity = true;
        }
    }

    private void Update()
    {

    }
    private void OnDisable()
    {
        _preloadComplete.OnEventRaised -= StartGame;
    }
}
