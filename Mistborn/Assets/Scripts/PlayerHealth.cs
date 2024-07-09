using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [Header("Knockback Parameters")]
    [SerializeField] private float knockbackForce = 10f;

    [Header("UI")]
    [SerializeField] private Slider healthSlider;

    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damage, Vector2 knockbackDirection)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        Knockback(knockbackDirection);
    }

    private void Die()
    {
        // Implementar comportamiento de muerte del jugador
        Debug.Log("Player died!");
    }

    private void Knockback(Vector2 direction)
    {
        rb.velocity = new Vector2(0, rb.velocity.y); // Detener el movimiento horizontal actual
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            // knockbackDirection += (new Vector2(knockbackDirection.x < 0 ? -10 : 10, knockbackDirection.y)).normalized;

            
            TakeDamage(10f, knockbackDirection); // Ajusta el daño según sea necesario
        }
    }
}
