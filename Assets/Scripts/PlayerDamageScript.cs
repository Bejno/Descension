using UnityEngine;
using System.Collections;

public class PlayerDamageScript : MonoBehaviour {

    public PlayerScript player;
    public TypewriterScript joke;
    public SpriteRenderer playerSprite;
    public Animator anim;
    public float flashDelay = 3f;
    public float damageDelay; // <-- Invincibility time in seconds
    public bool playJoke = true;

    private float invincTime;
    private bool isInvincible { get { return invincTime > 0; } }
    
    void Update () {
        invincTime = Mathf.Max(0f,invincTime - Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Damage" && !isInvincible && PlayerScript.win == false)
        {
            player.ModifyHealth(-1);
            SoundManagerScript.PlayDamageSound();
            TurnInvincible();
        }
        else if (other.gameObject.tag == "Shot" && !isInvincible && PlayerScript.win == false)
        {
            var death = other.GetComponent<DeathAnimationScript>();
            if(death)
               death.AtDeath();

            player.ModifyHealth(-1);
            SoundManagerScript.PlayDamageSound();
            TurnInvincible();
        }
        else if (other.gameObject.tag == "Life" && PlayerScript.win == false)
        {
            var death = other.GetComponent<DeathAnimationScript>();
            if (death)
                death.AtDeath();

            player.ModifyHealth(1);

            SoundManagerScript.PlayChrunch();

            if (playJoke)
            joke.Writeout();
        }
        else if (other.gameObject.tag == "Boss" && !isInvincible && PlayerScript.win == false)
        {
            player.ModifyHealth(-1);
            SoundManagerScript.PlayDamageSound();
            TurnInvincible();
        }
    }

    void TurnInvincible()
    {
        invincTime = damageDelay;
        anim.SetTrigger("Damaged");
        //playerSprite.color = new Color(1, 0.5f, 1, 1);
        StartCoroutine(spriteFlash());

    }

    IEnumerator spriteFlash()
    {
        while (isInvincible)
        {
            playerSprite.color = new Color(0.85f, 0, 0, 0.85f);
            yield return new WaitForSeconds(0.15f);
            playerSprite.color = new Color(0.85f, 0.85f, 0.85f, 0.85f);
            yield return new WaitForSeconds(0.15f);

        }
        playerSprite.color = new Color(1, 1, 1, 1);

    }
}
