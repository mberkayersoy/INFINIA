using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private Player1Movement player1Movement;

    // Animation parameteres 
    private int animIDHorizontal;
    private int animIDJump;
    private int animIDGrounded;
    private int animIDFreeFall;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player1Movement = GetComponent<Player1Movement>();
    }

    private void Start()
    {
        AssignAnimationIDs();
        player1Movement.OnFreeFallAction += PlayerMovement_OnFreeFallAction;
        player1Movement.OnGroundStateChangeAction += PlayerMovement_OnGroundStateChangeAction;
        player1Movement.OnJumpAction += PlayerMovement_OnJumpAction;
        player1Movement.OnSpeedChangeAction += PlayerMovement_OnSpeedChangeAction;
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
