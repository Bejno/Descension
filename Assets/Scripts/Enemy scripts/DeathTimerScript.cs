using UnityEngine;
using System.Collections;

public class DeathTimerScript : MonoBehaviour {

    public float deathTime;
    public bool randomTime = false;
    public bool spawnPartical = false;
    public bool startAtSpawn = true;
    public GameObject partical;

    private float time;

    void Start()
    {
        if (startAtSpawn)
        {
            delay();
        }
    }

    public void delay()
    {
        if (randomTime)
        {
            time = Random.value;

            if (spawnPartical)
                StartCoroutine(ParticalSpawn());

            Destroy(gameObject, time);
        }
        else
        {
            Destroy(gameObject, deathTime);
        }
    }

    IEnumerator ParticalSpawn()
    {
        yield return new WaitForSeconds(time);
        Instantiate(partical, transform.position + partical.transform.localPosition, partical.transform.rotation);


    }
}
