using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTimer : MonoBehaviour {

    public float updateRate = 1f;
    public List<Element> wave1 = new List<Element>();
    public List<Element> wave2 = new List<Element>();

    private float timePassed;

    void Start() {
        // Start wave 1
        StartCoroutine(Level(wave1));
    }

    public void Wave2()
    {
        // Start wave 2
        StartCoroutine(Level(wave2));
    }

    IEnumerator Level(List<Element> list) {
        timePassed = 0;

        while (list.Count > 0)
        {
            // Check for spawns
            list.RemoveAll(delegate (Element obj)
            {
                if (timePassed > obj.time)
                {
                    // SPAWN MEw
                    var clone = Instantiate(obj.obj, obj.position, Quaternion.identity) as GameObject;
                    clone.transform.SetParent(transform);

                    return true;
                }
                // NOT MY TIME YET
                return false;
            });
            
            // Increment time
            yield return new WaitForSeconds(updateRate);
            timePassed += updateRate;
        }
    }

    [System.Serializable]
    public struct Element {
        public GameObject obj;
        public float time;
        public Vector2 position;
    }

}
