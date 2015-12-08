using UnityEngine;
using System.Collections;

public class PlayerDamageScript : MonoBehaviour {

    public PlayerScript player;

    // Use this for initialization
    void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Damage")
        {
            player.health = Mathf.Min(player.maxHealth, --player.health);
        }
    }
}
