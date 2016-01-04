using UnityEngine;
using System.Collections;

public class KrucifixSelfDamageScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<HealthScript>();
        var death = GetComponent<DeathAnimationScript>();

        if (other.gameObject.tag == "Boss")
        {
            if (health)
            {
                health.Damage();
                death.AtDeath();
            }
        }
    }
}
