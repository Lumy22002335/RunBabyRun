using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsAnimationController : MonoBehaviour
{
    // Animator Hashes
    int xMove = Animator.StringToHash("XMove");
    int yMove = Animator.StringToHash("YMove");
    int changeStance = Animator.StringToHash("ChangeStance");
    int isCrawling = Animator.StringToHash("IsCrawling");
    int isWalking = Animator.StringToHash("IsWalking");
    int isMoving = Animator.StringToHash("IsMoving");

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateMoveAnimation(Vector2 movement)
    {
        animator.SetBool(isMoving, (movement.x != 0 || movement.y != 0));
        animator.SetFloat(xMove, movement.x);
        animator.SetFloat(yMove, movement.y);
    }

    public void UpdateMovementType(MovementType movementType)
    {
        animator.SetBool(isCrawling, movementType == MovementType.Crawl);
        animator.SetBool(isWalking, movementType == MovementType.Walk);
        animator.SetTrigger(changeStance);
    }
}
