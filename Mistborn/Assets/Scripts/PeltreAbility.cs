using UnityEngine;

public class PeltreAbility : MonoBehaviour
{
    public float damageIncrease = 1.5f;
    public float speedIncrease = 1.25f;
    public float healthIncrease = 1.25f;

    private PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Peltre"))
        {
            ActivatePeltre();
        }
    }

    void ActivatePeltre()
    {
        // Aumentar daño, velocidad y salud con Peltre
        player.damage *= damageIncrease;
        player.speed *= speedIncrease;
        player.health *= healthIncrease;

        // Agregar efecto visual de Peltre
        GetComponent<Animator>().SetTrigger("PeltreActivated");
    }
}