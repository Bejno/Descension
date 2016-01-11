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
            if (timer)
            {
                print("Fuck");
                if (wave == NextWave.Wave2)
                    timer.Wave2();
                else if (wave == NextWave.Wave3)
                    timer.Wave3();        
                else if (wave == NextWave.Wave4)
                    timer.Wave4();
                else if (wave == NextWave.Wave4)
                    timer.Wave4();
                else if (wave == NextWave.Boss)
                     timer.Boss();
            }
            else
                print("didnt find it...");

            Destroy(gameObject); 
        }

            
    }

    public enum NextWave
    {
        none, Wave2, Wave3, Wave4, Wave5, Boss
    }
}
