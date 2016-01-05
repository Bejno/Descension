using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextClearerScript : MonoBehaviour {

    public Text uiTarget;

    void Clear()
    {
        uiTarget.text = "";
    }
}
