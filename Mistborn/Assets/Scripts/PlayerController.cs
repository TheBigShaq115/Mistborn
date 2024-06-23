using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Change 'bool' to 'float'
    public float jumpForce = 10.0f;
    public float doubleJumpForce = 15.0f;

    public bool isGrounded = true; // Change 'private' or 'protected' to 'public'
    public bool hasDoubleJumped = false;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && !isGrounded && !hasDoubleJumped)
        {
            rb.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);
            hasDoubleJumped = true;
        }
    }
    public void Damage(int amount, Transform attackerTransform, int ragdollForce)
    {
        // Implement damage logic here
        // For example, reduce health by the damage amount
        health -= amount;

        // Apply ragdoll force if the player is killed
        if (health <= 0)
        {
            // Ragdoll logic here
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasDoubleJumped = false;
        }
    }
}