using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(50, 50);
    public float outsideDrag;
    public Rigidbody2D rbody;
    public int health, maxHealth;
    public GameObject deathPartical;

    private Vector2 outsideForces;

    void Start()
    {
        // Update the UI, and clamp the health
        SetHealth(health);
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(speed.x * inputX, speed.y * inputY);
        //movement *= Time.deltaTime;
        //transform.Translate(movement);

        outsideForces = Vector2.Lerp(outsideForces, Vector2.zero, outsideDrag * Time.deltaTime);

        rbody.velocity = movement + outsideForces;

    }

    public void AddOutsideForce(Vector2 force) {
        outsideForces += force;
    }

    public void SetHealth(int health)
    {
        this.health = Mathf.Clamp(health, 0, maxHealth);
        HealthGUIScript.instance.UpdateUIElements(health, maxHealth);

        if(health <= 0)
        {
            LevelTimer.playerDead = true;
            AimScript.playerDead = true;

            var activate = GetComponent<ActivatorScript>();
            activate.Activate();

            Instantiate(deathPartical, transform.position + deathPartical.transform.localPosition, deathPartical.transform.localRotation);
            Destroy(gameObject);
        }
    }

    public void ModifyHealth(int delta)
    {
        SetHealth(health + delta);
    }
    
}