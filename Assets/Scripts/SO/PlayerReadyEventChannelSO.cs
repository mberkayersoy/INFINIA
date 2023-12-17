using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerReadySO")]
public class PlayerReadyEventChannelSO : GenericEventChannelSO<PlayerState>
{

}

[System.Serializable]
public struct PlayerState
{
    public PlayerIDSO player;
    public Button readyButton;
    public bool isReady;
}
