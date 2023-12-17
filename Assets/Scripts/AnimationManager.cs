using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private IPlayer player;

    // Animation parameteres 
    private int animIDHorizontal;
    private int animIDJump;
    private int animIDGrounded;
    private int animIDFreeFall;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<IPlayer>();
    }

    private void Start()
    {
        AssignAnimationIDs();
        player.OnFreeFallAction += PlayerMovement_OnFreeFallAction;
        player.OnGroundStateChangeAction += PlayerMovement_OnGroundStateChangeAction;
        player.OnJumpAction += PlayerMovement_OnJumpAction;
        player.OnSpeedChangeAction += PlayerMovement_OnSpeedChangeAction;
    }

    private void PlayerMovement_OnFreeFallAction(bool isFreeFall)
    {
        animator.SetBool(animIDFreeFall, isFreeFall);
    }

    private void PlayerMovement_OnJumpAction(bool isJumping)
    {
        animator.SetBool(animIDJump, isJumping);
    }

    private void PlayerMovement_OnGroundStateChangeAction(bool isGrounded)
    {
        animator.SetBool(animIDGrounded, isGrounded);
    }

    private void PlayerMovement_OnSpeedChangeAction(float speed)
    {
        animator.SetFloat(animIDHorizontal, speed);
    }

    private void AssignAnimationIDs()
    {
        animIDHorizontal = Animator.StringToHash("Horizontal");
        animIDJump = Animator.StringToHash("Jump");
        animIDGrounded = Animator.StringToHash("Grounded");
        animIDFreeFall = Animator.StringToHash("FreeFall");
    }
}

public interface IPlayer
{
    public event Action<float> OnSpeedChangeAction;
    public event Action<bool> OnGroundStateChangeAction;
    public event Action<bool> OnJumpAction;
    public event Action<bool> OnFreeFallAction;
}
