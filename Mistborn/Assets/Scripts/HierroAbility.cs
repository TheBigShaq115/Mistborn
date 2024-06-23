using UnityEngine;

public class HierroAbility : MonoBehaviour
{
    public float attractForce = 10.0f;

    private PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Hierro"))
        {
            AttractToMetal();
        }
    }

    void AttractToMetal()
    {
        // Atraer al jugador a un objeto de metal cercano
        GameObject metalObject = FindNearestMetalObject();
        if (metalObject != null)
        {
            Vector2 direction = (metalObject.transform.position - transform.position).normalized;
            player.rb.AddForce(direction * attractForce, ForceMode2D.Impulse);
        }
    }

    GameObject FindNearestMetalObject()
    {
        // Buscar objeto de metal cercano
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5.0f);
        GameObject nearestMetalObject = null;
        float nearestDistance = Mathf.Infinity;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Metal"))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestMetalObject = collider.gameObject;
                }
            }
        }
        return nearestMetalObject;
    }
}