using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

    public float speed = 20;

	void Update () {
        transform.Rotate(Vector3.forward * speed);
    }
}
