using UnityEngine;
using System.Collections;

public class InGameButtonsScript : MonoBehaviour {

    public float timeSlowDeley = 1f;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("escape") && GameObject.Find("Player"))
        {
            if (LevelTimer.PauseMenu)
            {
                LevelTimer.PauseMenu = false;
            }
            else if (!LevelTimer.PauseMenu)
            {
                LevelTimer.PauseMenu = true;
            }
        }
    }
}
