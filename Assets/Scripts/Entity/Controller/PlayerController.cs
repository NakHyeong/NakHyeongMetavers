using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터의 입력을 처리하는 컨트롤러 클래스
public class PlayerController : BaseController
{
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private float jumpHeight = 5f;      // 점프 높이 (y축 속도 값)
    [SerializeField] private float jumpDuration = 0.8f;  // 점프 지속 시간

    // 점프 애니메이션용 상태
    private bool isJumping = false; // 점프 중인이 여부
    private float jumpTimer = 0f; //점프 남은시간

    // 시작 시 호출됨
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        HandleJump();
        FlipSpriteByDirection(_input);
    }

    private void HandleJump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true; // 스페이스를 받아 점프 시작
            jumpTimer = jumpDuration; //타이머 초기화(점프 남은시간)
            animationHandler?.Jump(true); // 점프 애니메이션 시작

            // 점프 시작 시 y축 속도 설정
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpHeight);
        }

        if (isJumping)
        {
            jumpTimer -= Time.deltaTime; // 남은 점프시간

            if (jumpTimer <= jumpDuration / 2f) //점프 중 천천히 내려오게 /2f
            {
                // y축 속도를 위에서 아래로 선형 보간하여 낙하 연출
                float t = 1 - (jumpTimer / (jumpDuration / 2f));
                float jumpSpeed = Mathf.Lerp(jumpHeight, -jumpHeight, t);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpSpeed);
            }

            if (jumpTimer <= 0f)
            {
                isJumping = false;
                animationHandler?.Jump(false);

                // 점프 종료 후 y축 속도 0으로 고정
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
            }
        }
    }

    private void FlipSpriteByDirection(Vector2 direction)
    {
        if (characterRenderer == null) return;
        if (direction.x != 0)
            characterRenderer.flipX = direction.x < 0;
    }
}
