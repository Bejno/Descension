using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public float health, maxHealth;
    public float points;
    public bool Boss = false;
    public GameObject deathParticle;

	public void Damage () {

        health -= 1;

        if (health <= 0)
            Death();
	}

    void Death() {

        var score = FindObjectOfType<ScoreScript>();
        score.AddScore(points);

        Instantiate(deathParticle, transform.position + deathParticle.transform.localPosition, deathParticle.transform.localRotation);

        Destroy(gameObject);
    }
}
