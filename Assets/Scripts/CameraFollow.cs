using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offSet;
    [SerializeField] private float smoothTime;
    private Vector3 velocity;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offSet;
            desiredPosition.y = 5;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothTime);
            transform.position = smoothedPosition;

            transform.LookAt(target);  // Kamerayý hedefe doðru çevir
        }
    }
}
