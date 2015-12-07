using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public float health, maxHealth;
    public bool Boss = false;
    public GameObject deathParticle;

    private float points = 0;
    private string zeros = "000";

    void Start () {
	
	}

	public void Damage () {

        health -= 1;

        if (health <= 0)
            Death();
	}

    void Death() {

        if (points >= 10 && points < 100)
        {
            zeros = "00";
        }
        else if (points >= 100 && points < 1000)
        {
            zeros = "0";
        }
        else if (points >= 1000)
        {
            zeros = "";
        }

        TextMesh textObject = GameObject.Find("Score").GetComponent<TextMesh>();
        textObject.text = "[Score: " + zeros + points.ToString() + "]";

        Destroy(gameObject);
    }
}
