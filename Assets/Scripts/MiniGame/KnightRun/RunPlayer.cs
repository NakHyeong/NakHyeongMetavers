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
            Debug.LogError("Rigidbody2D�� �����ϴ�.");
        if (_animator == null)
            Debug.LogError("Animator�� �����ϴ�.");
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

        // �׻� ������ �̵�
        _rigidbody.velocity = new Vector2(moveSpeed, _rigidbody.velocity.y);

        // ���� ó��
        if (isJumpPressed)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            isJumpPressed = false;
            isGrounded = false; // ���� ���Ŀ� ���� ����
        }

        // �ִϸ��̼� ó��
        _animator.SetBool("IsGrounded", isGrounded);
    }

    // �ٴڰ� �浹�ϸ� ����
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.collider.CompareTag("Hole"))
        {
            Debug.Log("���ۿ� �������ϴ�!");
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
