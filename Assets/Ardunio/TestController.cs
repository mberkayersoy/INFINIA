using _Game.Extensions.Ragdoll;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private float hInput;
    [SerializeField] private float vInput;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float forceMagnitudeHips;

    //private RagdollController _ragdollController;
    void Start()
    {
        //_ragdollController = GetComponent<RagdollController>();
    }

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(0, vInput, hInput).normalized;

        //_ragdollController.AddForce(BoneName.LeftUpperLeg, Vector3.down * forceMagnitude, ForceMode.Force);
        //_ragdollController.AddForce(BoneName.RightUpperLeg, Vector3.down * forceMagnitude, ForceMode.Force);
        //_ragdollController.AddForce(BoneName.Hips, Vector3.up * forceMagnitudeHips, ForceMode.Force);
        
    }
}
