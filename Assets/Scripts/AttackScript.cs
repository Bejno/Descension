using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackScript : MonoBehaviour {

    public Animator anim;
    public PlayerScript player;
    public float attackPush = 1f;
    [Range(0, 125)]
    public float stamina;
    public float staminaRegenRate = 3f; // Stamina points / second
    public float staminaRegenDelay = 3f; // Time in seconds 

    public Slider staminaSlider;

    public GameObject shotLeft;
    public GameObject shotRight;
    public GameObject shotDown;

    private GameObject currentShot;
    private float staminaRegenTime; // Time left

    // Use this for initialization
    void Start () {
        staminaSlider.maxValue = staminaSlider.value = 125;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Space") && stamina >= 25)      {
            AttackDown();
            //player.health = Mathf.Min(player.maxHealth, --player.health);
        }
        else if (Input.GetButtonDown("AttackLeft") && stamina >= 25)      {
            AttackLeft();
            //player.health = Mathf.Min(player.maxHealth, ++player.health);
        }
        else if (Input.GetButtonDown("AttackRight") && stamina >= 25)      {
            AttackRight();
        }

        // Wait the delay
        if (staminaRegenTime > 0)
            staminaRegenTime = Mathf.Max(staminaRegenTime - Time.deltaTime, 0f);
        // Regenerate stamina
        if (stamina < 125 && staminaRegenTime <= 0)
            staminaSlider.value = stamina = Mathf.Min(stamina + Time.deltaTime * staminaRegenRate, 125f);
        
    }

    private void DrainStamina(float amount)
    {
        staminaRegenTime = staminaRegenDelay;
        stamina -= amount;
        staminaSlider.value -= 25;
    }

    private void AttackDown()
    {
        //Drain stamina
        DrainStamina(25);
        // Activate animations
        anim.SetTrigger("SwingLeft");
        anim.SetTrigger("SwingRight");
        // Knockback
        player.AddOutsideForce(Vector2.up * attackPush);

        // Remember the attack direction
        currentShot = shotDown;
    }

    private void AttackLeft()
    {
        //Drain stamina
        DrainStamina(25);
        // Activate animation
        anim.SetTrigger("SwingLeft");
        // Knockback
        player.AddOutsideForce(Vector2.right * attackPush);

        // Remember the attack direction
        currentShot = shotLeft;
    }

    private void AttackRight()
    {
        //Drain stamina
        DrainStamina(25);
        // Activate animation
        anim.SetTrigger("SwingRight");
        // Knockback
        player.AddOutsideForce(Vector2.left * attackPush);

        // Remember the attack direction
        currentShot = shotRight;
    }

    private void SpawnDamage() {
        // Error checking
        if (currentShot == null)
            return;

        // Spawn it
        print("Spawn " + currentShot);
        Instantiate(currentShot, transform.position + currentShot.transform.localPosition, currentShot.transform.localRotation);

        // Reset
        currentShot = null;
    }
    
}
