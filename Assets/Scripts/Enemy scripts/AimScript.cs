using UnityEngine;
using System.Collections;

public class AimScript : MonoBehaviour {
    
    public GameObject bullet;
    public float speed = 5;
    public float turnSpeed = 200f;
    public bool shotSelf = false;

    public static bool playerDead = false;

    private Transform Player;

    void Start()
    {
       Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (!playerDead)
        {
            Vector3 delta = Player.position - transform.position;
            float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

            var current = transform.eulerAngles;

            current.z = Mathf.MoveTowardsAngle(current.z, angle, Time.deltaTime * turnSpeed);

            transform.eulerAngles = current;

            // Attack(); }


        }
    }

    public void Attack()
    {

        if (!shotSelf)
        {
            var clone = Instantiate(bullet, transform.position, transform.localRotation) as GameObject;
            clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.right.x, transform.right.y) * speed, ForceMode2D.Impulse);
            //Destroy(clone, 10);
        }
        else if (shotSelf)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.right.x, transform.right.y) * speed, ForceMode2D.Impulse);
        }
    }
}
