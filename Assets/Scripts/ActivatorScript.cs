using UnityEngine;
using System.Collections;

public class ActivatorScript : MonoBehaviour {

    public GameObject[] activate;

    public void Activate()
    {
        foreach (var obj in activate)
        {
            obj.SetActive(true);
        }
    }


}
