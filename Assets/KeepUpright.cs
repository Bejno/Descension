using UnityEngine;
using System.Collections;

public class KeepUpright : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = Vector3.Scale(new Vector3(1, 1, 0), transform.eulerAngles);
	}
}
