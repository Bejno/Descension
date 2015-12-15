using UnityEngine;
using System.Collections;

public class NunSpawningCloudScript : MonoBehaviour {

    public float nuns = 10;
    public GameObject nun;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnTimer());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnTimer()
    {
        while (nuns > 0)
        {

            yield return new WaitForSeconds(0.05f);

            var pos = transform.position + nun.transform.localPosition;
            pos.x += Random.Range(-7, 8);
            Instantiate(nun, pos, nun.transform.localRotation);
            nuns -= 1;

        }
    }
}
