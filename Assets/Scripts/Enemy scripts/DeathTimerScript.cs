using UnityEngine;
using System.Collections;

public class DeathTimerScript : MonoBehaviour {

    public float deathTime;

    void Start()
    {
        Destroy(gameObject, deathTime);
    }
}
