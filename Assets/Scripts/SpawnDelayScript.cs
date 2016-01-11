using UnityEngine;
using System.Collections;

public class SpawnDelayScript : MonoBehaviour {

    public GameObject spawn;
    public float spawnTime = 1f;

	// Use this for initialization
	void Start () {

       
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {

        yield return new WaitForSeconds(spawnTime);
        var clone = Instantiate(spawn, transform.position + spawn.transform.localPosition, spawn.transform.localRotation) as GameObject;
        var timer = GameObject.Find("LevelTimer");
        clone.transform.SetParent(timer.transform);
    }

}
