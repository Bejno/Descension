using UnityEngine;
using System.Collections;

public class PlayerDamageScript : MonoBehaviour {

    public PlayerScript player;
    public Animator anim;
    public float damageDelay; // <-- Invincibility time in seconds

    private float invincTime;
    private bool isInvincible { get { return invincTime > 0; } }
    
    void Update () {
        invincTime = Mathf.Max(0f,invincTime - Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Damage" && !isInvincible)
        {
            player.ModifyHealth(-1);
            TurnInvincible();
        }
        else if (other.gameObject.tag == "Shot" && !isInvincible)
        {
            var death = other.GetComponent<DeathAnimationScript>();
            if(death)
               death.AtDeath();

            player.ModifyHealth(-1);
            TurnInvincible();
        }
        else if (other.gameObject.tag == "Life")
        {
            var death = other.GetComponent<DeathAnimationScript>();
            if (death)
                death.AtDeath();

            player.ModifyHealth(1);
        }
    }

    void TurnInvincible()
    {
        invincTime = damageDelay;
        anim.SetTrigger("Damaged");
    }
}
