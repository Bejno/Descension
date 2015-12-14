using UnityEngine;
using System.Collections;

public class NextWaveScript : MonoBehaviour {

    public float points = 1;
    public NextWave wave;

    public void LosePoints()
    {
        points -= 1;

        if (points <= 0)  {

            var timer = GetComponentInParent<LevelTimer>();
            if(timer)
            {
                if (wave == NextWave.Wave2)
                    timer.Wave2();
            } else

                print("didnt find it...");

            Destroy(gameObject); 
        }
    }

    public enum NextWave
    {
        none, Wave2
    }
}
