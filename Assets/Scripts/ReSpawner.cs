using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -16)
        {
            transform.position = spawnPoint.position;
        }
    }
}
