﻿using UnityEngine;
using System.Collections;

public class AimScript : MonoBehaviour {
    
    public GameObject bullet;
    public float speed = 5;

    private Transform Player;

    void Start()
    {
       Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 delta = Player.position - transform.position;
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

        var current = transform.eulerAngles;

        current.z = Mathf.MoveTowardsAngle(current.z, angle, Time.deltaTime * 200f);

        transform.eulerAngles = current;

       // Attack();

    }

    public void Attack()
    {

        var clone = Instantiate(bullet, transform.position, transform.localRotation) as GameObject;
        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.right.x, transform.right.y) * speed, ForceMode2D.Impulse);
        //Destroy(clone, 10);
    }
}