using UnityEngine;
using System.Collections;

public class ActivatorScript : MonoBehaviour {

    public GameObject[] activate;
    public bool ActivateTrue = true;

    public void Activate()
    {
        if (ActivateTrue)
        {
            foreach (var obj in activate)
            {
                obj.SetActive(true);
            }

        }
        else
        {
            foreach (var obj in activate)
            {
                obj.SetActive(false);
            }
        }

        
    }


}
