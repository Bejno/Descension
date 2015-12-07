using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(50, 50);
    public float outsideDrag;
    public Rigidbody2D rbody;
    public float health, maxHealth;


    private Vector2 outsideForces;



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

        HealthGUIScript.instance.UpdateUIElements(health, maxHealth);
    }

    public void AddOutsideForce(Vector2 force) {
        outsideForces += force;
    }
}