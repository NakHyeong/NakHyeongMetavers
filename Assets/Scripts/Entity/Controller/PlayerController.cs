using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터 입력을 처리하는 컨트롤러 클래스
public class PlayerController : BaseController
{
    private Camera camera; // 메인 카메라 참조

    // 시작 시 호출됨 (BaseController의 Start도 함께 호출됨)
    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    // 키보드 및 마우스 입력 처리
    protected override void HandleAction()
    {
        // 방향키(WASD 또는 화살표) 입력 처리
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 이동 방향 설정
        movementDirection = new Vector2(moveX, moveY).normalized;

        // 마우스 위치 가져오기 (스크린 → 월드 좌표)
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);

        // 바라보는 방향 계산 (캐릭터 위치 기준)
        lookDirection = (worldPos - (Vector2)transform.position);

        // 너무 가까우면 무시, 그렇지 않으면 방향 정규화
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}
