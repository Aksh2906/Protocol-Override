using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x;
    int lastGroundDirection = 1;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] Animator animator;

    public bool isGrounded;
    public bool stairAvailable;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = 0.15f;
    [SerializeField] LayerMask groundLayer;



    void Update()
    {
        CheckGround();
        
        x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {
            RuleManager.Instance.CheckMoveLeft(x);
            lastGroundDirection = (int)Mathf.Sign(x);

        }
        animator.SetInteger("State", x != 0 ? 1 : 0);

        if (GlitchManager.Instance.rewindTime && Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<RewindController>().Rewind();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GlitchManager.Instance.gravityFlip)
            {
                // Toggle gravity
                rb.gravityScale *= -1;
                AudioManager.Instance.PlaySFX(AudioManager.Instance.gravityFlip);

                // Stop vertical motion
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
               //float yAngle = (lastGroundDirection == -1) ? 180f : 0f;
                // float zAngle = (rb.gravityScale > 0) ? 180f : 0f;

                // transform.rotation = Quaternion.Euler(0f, 0f, zAngle);

    

            }
            else if (isGrounded)
            {
                // Normal jump before glitch unlock
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                AudioManager.Instance.PlaySFX(AudioManager.Instance.jump);
            }

            animator.SetInteger("State", 2);
            RuleManager.Instance.CheckJump();
        }



        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void FixedUpdate()
    {
        if (stairAvailable)
        {
            rb.gravityScale = 0;
            float v = Input.GetAxisRaw("Vertical");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, v * speed);
            return;
        }


        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);


        
    }

    void Shoot()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.shoot);
        RuleManager.Instance.CheckShoot();
        animator.SetInteger("State", 4);
        var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().direction = lastGroundDirection;
    }
    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        RuleManager.Instance.CheckTouchRed(collision.gameObject);
    }


}
