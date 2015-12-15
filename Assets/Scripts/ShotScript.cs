using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<HealthScript>();
        if (health)
        {
            health.Damage();
           // Destroy(gameObject);
        }
    }
}
