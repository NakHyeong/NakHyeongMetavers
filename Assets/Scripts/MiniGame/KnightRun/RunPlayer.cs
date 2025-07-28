using UnityEngine;

public class RunPlayer : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public float jumpForce = 7f;
    public float moveSpeed = 5f;

    public bool isDead = false;
    private float deathCooldown = 0f;

    private bool isJumpPressed = false;
    private bool isGrounded = false;

    private bool isGameOver = false; // 게임오버 상태 체크

    public bool godMode = false;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();

        if (_rigidbody == null)
            Debug.LogError("Rigidbody2D가 없습니다.");
        if (_animator == null)
            Debug.LogError("Animator가 없습니다.");
        _animator.SetBool("IsDie", false);
        isDead = false;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }


    void Update()
    {
        if (isDead)
        {
            if (deathCooldown > 0f)
            {
                deathCooldown -= Time.deltaTime;

                // 쿨다운이 0 이하로 떨어지면 GameOver 실행
                if (deathCooldown <= 0f)
                {
                    gameManager.GameOver();
                }
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!isGrounded) 
                return;

            isJumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (isDead) return;

        Vector2 velocity = _rigidbody.velocity;
        velocity.x = moveSpeed;

        if (isJumpPressed)
        {
            velocity.y = jumpForce;
            isJumpPressed = false;
            isGrounded = false; // 점프하면 공중 상태로
        }

        _rigidbody.velocity = velocity;

        _animator.SetBool("IsJump", !isGrounded);
        _animator.SetBool("IsMove", moveSpeed > 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.CompareTag("Hole"))
        {
            if (!godMode)  // 무적 모드가 아니면 죽음 처리
            {
                Die();
            }
            else
            {
                Debug.Log("GodMode 활성화 중, 구멍 통과!");
            }
        }
    }
    private void Die()
    {
        if (isDead) return;

        isDead = true;
        deathCooldown = 3f;

        _animator.SetTrigger("IsDie");
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }
}
