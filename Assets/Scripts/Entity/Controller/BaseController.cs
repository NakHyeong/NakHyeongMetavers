using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 캐릭터(플레이어, NPC 등)의 공통 동작을 처리하는 기본 클래스
public class BaseController : MonoBehaviour
{
    // 이동 방향
    protected Vector2 movementDirection = Vector2.zero;

    // 바라보는 방향 (마우스 방향 등)
    protected Vector2 lookDirection = Vector2.zero;

    // Rigidbody2D 참조 (물리 이동을 위한)
    protected Rigidbody2D rigid;

    // 시작 시 호출되는 메서드 (PlayerController에서 override 가능)
    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // 매 프레임마다 호출됨 (입력 처리용)
    protected virtual void HandleAction()
    {
        // 자식 클래스에서 구현할 예정 (PlayerController 등)
    }

    // 물리 업데이트 처리
    private void FixedUpdate()
    {
        Move();
    }

    // 실제 이동 처리
    protected void Move()
    {
        if (movementDirection != Vector2.zero)
        {
            rigid.MovePosition(rigid.position + movementDirection * Time.fixedDeltaTime * 5f);
        }
    }

    // 매 프레임마다 호출되는 업데이트 (입력 처리 연결)
    private void Update()
    {
        HandleAction();
    }
}
