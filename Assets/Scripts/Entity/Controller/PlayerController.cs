using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터의 입력을 처리하는 컨트롤러 클래스
public class PlayerController : BaseController
{
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce = 5f;
    // 시작 시 호출됨
    protected override void Start()
    {
        base.Start();
    }

    // 키보드 입력 처리
    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 입력된 방향을 정규화해서 이동 방향으로 설정
        movementDirection = new Vector2(horizontal, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    protected void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0); // 수직 속도 초기화
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (animator != null)
            animator.SetTrigger("Jump");
    }

    protected bool IsGrounded()
    {
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.2f;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, LayerMask.GetMask("Ground"));

        return hit.collider != null;
    }
}
