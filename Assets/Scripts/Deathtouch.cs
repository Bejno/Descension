using UnityEngine;
using System.Collections;

public class Deathtouch : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
       
    }
}
