using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayer : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public float jumpForce = 7f;
    public float moveSpeed = 3f;

    private bool isGrounded = false;
    private bool isJumpPressed = false;
    private bool isDead = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        if (_rigidbody == null)
            Debug.LogError("Rigidbody2D가 없습니다.");
        if (_animator == null)
            Debug.LogError("Animator가 없습니다.");
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                isJumpPressed = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isDead) return;

        // 항상 앞으로 이동
        _rigidbody.velocity = new Vector2(moveSpeed, _rigidbody.velocity.y);

        // 점프 처리
        if (isJumpPressed)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            isJumpPressed = false;
            isGrounded = false; // 점프 직후엔 공중 상태
        }

        // 애니메이션 처리
        _animator.SetBool("IsGrounded", isGrounded);
    }

    // 바닥과 충돌하면 착지
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.collider.CompareTag("Hole"))
        {
            Debug.Log("구멍에 빠졌습니다!");
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        _animator.SetTrigger("Die");
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }
}
