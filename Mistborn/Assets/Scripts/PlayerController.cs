using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxCoins = 10;
    private int currentCoins;
    private bool isGrounded;
    private bool hasSteelPower;
    private bool hasPewterPower;
    private bool hasIronPower;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentCoins = maxCoins;
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
        Dash();
        BurnSteel();
        BurnPewter();
        AttractIron();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (move < 0) sr.flipX = true;
        else if (move > 0) sr.flipX = false;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded && hasSteelPower && currentCoins > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            currentCoins--;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Implementar ataque en la dirección del jugador
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            // Implementar dash en la dirección del movimiento
        }
    }

    void BurnSteel()
    {
        if (Input.GetKeyDown(KeyCode.C) && currentCoins > 0)
        {
            // Implementar lanzamiento de monedas
            currentCoins--;
        }
    }

    void BurnPewter()
    {
        if (Input.GetKeyDown(KeyCode.V) && hasPewterPower)
        {
            // Implementar aumento de fuerza, velocidad y curación
        }
    }

    void AttractIron()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasIronPower)
        {
            // Implementar atracción a barras de metal
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
