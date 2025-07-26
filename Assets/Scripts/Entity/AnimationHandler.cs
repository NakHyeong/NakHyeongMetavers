using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsJump = Animator.StringToHash("IsJump");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 direction)
    {
        // 속도 벡터의 크기로 이동 판정
        animator.SetBool(IsMoving, direction.magnitude > 0.1f);
    }

    public void Jump(bool isJumping)
    {
        // 점프 여부로 애니메이션 전환
        animator.SetBool(IsJump, isJumping);
    }
}
