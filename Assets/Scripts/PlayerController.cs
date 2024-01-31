using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 7;
    [SerializeField] private float jumpHeight = 150;
    [SerializeField] private float FireRate = 0.5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform GunMuzzle;
    [SerializeField] private GameObject RocketPrefab;
    
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private bool isFacingRight;
    private bool isGrounded;
    private float nextFire;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        isGrounded = false;
        nextFire = 0f;
    }

    private void Update()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", false);
            rigidbody2d.AddForce(new Vector2(0, jumpHeight));
        }

        if (Time.time >= nextFire && Input.GetAxisRaw("Fire1") != 0)
        {
            nextFire = Time.time + FireRate;
            Instantiate(RocketPrefab, GunMuzzle.position, Quaternion.Euler(0, 0, isFacingRight ? 0 : 180));
        }
    }
    
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));
        rigidbody2d.velocity = new(
            move * maxSpeed,
            rigidbody2d.velocity.y
        );

        if ((move > 0 && !isFacingRight) || (move < 0 && isFacingRight)) Flip();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .15f, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("VerticalSpeed", rigidbody2d.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new(
            transform.localScale.x * -1,
            transform.localScale.y,
            transform.localScale.z);
    }
}
