using UnityEngine;
using System.Collections;

public class NunBossScript : MonoBehaviour {

    public GameObject Krucifix1;
    public GameObject Krucifix2;
    public GameObject NunSpawner;

    void Start()
    {
        Krucifix();
    }

    void Krucifix()
    {
        Instantiate(Krucifix1, transform.position + Krucifix1.transform.localPosition, Krucifix1.transform.localRotation);
        Instantiate(Krucifix2, transform.position + Krucifix2.transform.localPosition, Krucifix2.transform.localRotation);
    }

    void Nuns()
    {
        Instantiate(NunSpawner, transform.position + NunSpawner.transform.localPosition, NunSpawner.transform.localRotation);
    }
        
}
