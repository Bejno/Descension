using UnityEngine;
using System.Collections;

public class RingScript : MonoBehaviour {

    public float speed = 50;

	void Update () {
        transform.Rotate(0, 0, Time.deltaTime * speed);
	}
}
