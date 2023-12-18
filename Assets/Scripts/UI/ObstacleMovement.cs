using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float duration = 3f;
    [SerializeField] private float _endValue = 3f;

    [SerializeField] private float distance = 2f;

    void Start()
    {
        MoveUpDownLoop();
    }

    void MoveUpDownLoop()
    {
        transform.DOLocalMoveY(transform.localPosition.y + distance, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                transform.DOLocalMoveY(transform.localPosition.y - distance, duration)
                    .SetEase(Ease.Linear)
                    .OnComplete(() => MoveUpDownLoop());
            });
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }
}
