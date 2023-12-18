using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystemsCookbook;

public class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] private PlayerIDEventChannelSO _broadcastWinner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerID winner))
        {
            _broadcastWinner.RaiseEvent(winner.playerID);
        }
    }
}
