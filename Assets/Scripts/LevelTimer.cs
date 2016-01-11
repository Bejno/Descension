using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTimer : MonoBehaviour {

    public float updateRate = 1f;
    public float timeSlowDeley = 1f;
    public List<Element> wave1 = new List<Element>();
    public List<Element> wave2 = new List<Element>();
    public List<Element> wave3 = new List<Element>();
    public List<Element> wave4 = new List<Element>();
    public List<Element> wave5 = new List<Element>();
    public List<Element> boss = new List<Element>();

    public static bool PauseMenu = false;
    public static bool playerDead = false;
    private float timePassed;

    void Start() {
        // Start wave 1
        StartCoroutine(Level(wave1));
    }

    void Update()
    {
        if (playerDead)
        {
            // Slow down
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, 0f, Time.unscaledDeltaTime / timeSlowDeley);
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
           /* var activate = GetComponent<ActivatorScript>();
            activate.Activate();*/
        }
        else if (PauseMenu && !playerDead)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }

    public void Wave2()
    {
        // Start wave 2
        StartCoroutine(Level(wave2));
    }

    public void Wave3()
    {
        // Start wave 3
        StartCoroutine(Level(wave3));
    }

    public void Wave4()
    {
        // Start wave 4
        StartCoroutine(Level(wave4));
    }

    public void Wave5()
    {
        // Start wave 5
        StartCoroutine(Level(wave5));
    }

    public void Boss()
    {
        // Start Boss
        StartCoroutine(Level(boss));
    }

    IEnumerator Level(List<Element> list) {
        timePassed = 0;

        while (list.Count > 0 && !playerDead)
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
