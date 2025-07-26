using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 캐릭터(플레이어, NPC 등)의 공통 동작을 처리하는 기본 클래스
public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected AnimationHandler animationHandler;

    protected Vector2 _input;
    [SerializeField] protected float moveSpeed = 5f;   // 이동 속도

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
    }

    // 입력 처리 (이동 방향 설정 등)
    protected virtual void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(horizontal, vertical).normalized;
        _input = input;

        // 이동 속도에 맞춰 Rigidbody 속도 설정
        _rigidbody.velocity = input * moveSpeed;

        // 이동 애니메이션 호출
        animationHandler?.Move(input);
    }
}
