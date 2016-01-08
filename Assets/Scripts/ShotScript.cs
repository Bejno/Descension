using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<HealthScript>();
        var bounce = other.GetComponent <ShotBounceScript>();
        if (health)
        {
            health.Damage();
        }
        else if (bounce)
        {
            if (gameObject.tag == ("PlayerShotDown"))
            {
                bounce.BounceDown();
            }
            else if (gameObject.tag == ("PlayerShotLeft"))
            {
                bounce.BounceLeft();
            }
            else if (gameObject.tag == ("PlayerShotRight"))
            {
                bounce.BounceRight();
            }
        }
    }
}
