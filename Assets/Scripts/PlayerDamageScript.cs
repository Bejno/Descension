using UnityEngine;
using System.Collections;

public class PlayerDamageScript : MonoBehaviour {

    public PlayerScript player;
    public float invinTime = 1f;
    private bool invincibility = false;

    // Use this for initialization
    void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Damage"/* && invincibility == false*/)
        {
            player.health = Mathf.Min(player.maxHealth, --player.health);
           // invincibility = true;

           // InvincibilityTimer();
        }
        else if (other.gameObject.tag == "Shot"/* && invincibility == false*/)
        {
            Destroy(other.gameObject);

            if (invincibility == false)  {
                player.health = Mathf.Min(player.maxHealth, --player.health);
               // invincibility = true;

                //InvincibilityTimer();
            }
        }
    }

    /*
    IEnumerator InvincibilityTimer()
    {
       
        yield return new WaitForSeconds(invinTime);
       GetComponent<SpriteRenderer>().color = Color.red;
        invincibility = false;
    }*/
}
