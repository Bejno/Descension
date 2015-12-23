using UnityEngine;
using System.Collections;

public class InGameButtonsScript : MonoBehaviour {

    public bool inGameMenu = false;
    public float timeSlowDeley = 1f;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("escape"))
        {
            if (inGameMenu)
            {
                inGameMenu = false;
            }
            else if (!inGameMenu)
            {
                inGameMenu = true;
            }
        }

        if (inGameMenu)
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
}
