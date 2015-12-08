using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    private float points = 0;
    private string zeros = "000";

    public void AddScore (float newPoints)
    {

        points += newPoints;

        if (points >= 10 && points < 100)
        {
            zeros = "00";
        }
        else if (points >= 100 && points < 1000)
        {
            zeros = "0";
        }
        else if (points >= 1000)
        {
            zeros = "";
        }

        TextMesh textObject = GameObject.Find("Score").GetComponent<TextMesh>();
        textObject.text = "[Score: " + zeros + points.ToString() + "]";

    }
}
