using UnityEngine;
using System.Collections;

public class Deathtouch : MonoBehaviour {

    private float fuck = 0;
    private string zeros = "000";

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        fuck += 75;
        if (fuck >= 10 && fuck < 100)
        {
            zeros = "00";
        }
        else if(fuck >= 100 && fuck < 1000)
        {
            zeros = "0";
        }
        else if (fuck >= 1000)
        {
            zeros = "";
        }

        TextMesh textObject = GameObject.Find("Score").GetComponent<TextMesh>();
        textObject.text = "[Score: "+zeros+fuck.ToString()+"]";
    }
}
