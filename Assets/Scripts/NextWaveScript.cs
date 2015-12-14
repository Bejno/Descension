using UnityEngine;
using System.Collections;

public class NextWaveScript : MonoBehaviour {

    public float points = 1;
    public string wave = "Wave2";

    void LosePoints()
    {
        points -= 1;

        if (points <= 0)  {

            var timer = GetComponent<LevelTimer>();
            if(timer)
            timer.wave();
        }
    }
}
