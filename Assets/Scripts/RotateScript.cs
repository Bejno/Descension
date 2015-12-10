using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

    private Vector3 pos;
    public GameObject player;

    void Start()
    {
       // player = GameObject.Find("First Person Controller");
    }

    void Update()
    {
        pos = player.transform.position;
        pos.z = transform.position.z;
        transform.LookAt(pos, Vector3.right);
    }
}
