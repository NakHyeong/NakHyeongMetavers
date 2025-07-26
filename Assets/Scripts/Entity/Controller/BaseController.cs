using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 캐릭터(플레이어, NPC 등)의 공통 동작을 처리하는 기본 클래스
public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected Vector2 movementDirection = Vector2.zero;
    protected AnimationHandler animationHandler;

    [SerializeField] protected float moveSpeed = 5f;   // 이동 속도
    [SerializeField] protected float jumpForce = 10f;  // 점프 힘
    [SerializeField] protected Transform groundCheck;  // 땅에 닿았는지 체크할 위치
    [SerializeField] protected LayerMask groundLayer;  // 땅 레이어
    [SerializeField] protected float groundCheckRadius = 0.2f; // 체크 범위 반지름

    protected bool isGrounded;  // 착지 여부
    protected bool isJumping;   // 점프 중인지 여부

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        HandleAction();
        Jump();
        CheckGround();
    }

    // 이동 처리
    // 입력 처리 (이동 방향 설정 등)
    protected virtual void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(horizontal, vertical).normalized;

        _rigidbody.velocity = new Vector2(move.x * moveSpeed, _rigidbody.velocity.y);
        animationHandler.Move(move);
    }

    // 점프 처리
    protected virtual void Jump()
    {
        // 스페이스바 누르고 착지 상태면 점프
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            isJumping = true;
            animationHandler.Jump(true); // 점프 애니메이션 true
        }

        // 땅에 닿으면 점프 종료 처리
        if (isGrounded && isJumping)
        {
            isJumping = false;
            animationHandler.Jump(false); // 점프 애니메이션 false
        }
    }

    // 땅에 닿았는지 체크
    protected virtual void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // 착지 판정 디버그용 (에디터에서만 보임)
    protected virtual void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
