using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 캐릭터(플레이어, NPC 등)의 공통 동작을 처리하는 기본 클래스
public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    [SerializeField] private float moveSpeed = 3f;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
    }

    private void Update()
    {
        HandleAction();

        // 이동 방향이 있을 때, 좌우 반전 처리
        if (movementDirection != Vector2.zero)
            FlipSpriteByDirection(movementDirection);
    }

    protected virtual void HandleAction()
    {
        // 기본 입력 처리 (WASD + 점프)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        Move(movementDirection);
    }

    protected void Move(Vector2 direction)
    {
        // 방향 입력 (WASD)
        float moveX = direction.x;
        float moveY = direction.y;

        Vector2 velocity;

        if (IsGrounded())
        {
            velocity = new Vector2(moveX, moveY).normalized * moveSpeed;
            _rigidbody.velocity = velocity;
        }
        else
        {
            float currentY = _rigidbody.velocity.y;
            velocity = new Vector2(moveX, 0f).normalized * moveSpeed;
            _rigidbody.velocity = new Vector2(velocity.x, currentY);
        }

    }
    protected virtual bool IsGrounded() => false;

    private void FlipSpriteByDirection(Vector2 direction)
    {
        if (direction.x != 0)
            characterRenderer.flipX = direction.x < 0;
    }
}