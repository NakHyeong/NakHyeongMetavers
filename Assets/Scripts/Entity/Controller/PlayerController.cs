using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터의 입력을 처리하는 컨트롤러 클래스
public class PlayerController : BaseController
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer characterRenderer;
    // 시작 시 호출됨
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        FlipSpriteByDirection(movementDirection);
    }

    private void FlipSpriteByDirection(Vector2 direction)
    {
        if (direction.x != 0)
            characterRenderer.flipX = direction.x < 0;
    }
}
