using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 3f;

    private void OnEnable()
    {
        RotateObject();
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }

    void RotateObject()
    {
        transform.DORotate(new Vector3(360f, 0f, 0f), _rotationSpeed, RotateMode.FastBeyond360)
            .SetLoops(-1)
            .SetEase(Ease.Linear);
    }
}
