using UnityEngine;
using System.Collections;

public class MusicDestroyer : MonoBehaviour {


	void Start () {

        var music = GameObject.Find("Level Music");
        Destroy(music);

	}
	
}
