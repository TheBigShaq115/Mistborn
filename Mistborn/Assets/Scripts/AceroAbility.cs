using UnityEngine;

public class AceroAbility : MonoBehaviour
{
    public float coinForce = 10.0f;
    public float doubleJumpForce = 15.0f;

    private PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Acero") && player.isGrounded)
        {
            LaunchCoin();
        }

        if (Input.GetButtonDown("Acero") && !player.isGrounded && !player.hasDoubleJumped)
        {
            DoubleJump();
        }
    }

    void LaunchCoin()
    {
        // Lanzar moneda como proyectil
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.GetComponent<Rigidbody2D>().AddForce(Vector2.right * coinForce, ForceMode2D.Impulse);
    }

    void DoubleJump()
    {
        // Realizar doble salto con Acero
        player.rb.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);
        player.hasDoubleJumped = true;
    }
}