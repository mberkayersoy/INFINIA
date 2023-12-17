using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigSO")]
public class LevelConfigSO : ScriptableObject
{
    public GameObject LevelPrefab;
    public Vector3 StartPoint;
}
