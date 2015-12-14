using UnityEngine;
using System.Collections;

public class AttackTriggerScript : MonoBehaviour {

    public float delay = 1f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {

        yield return new WaitForSeconds(delay);
        var trigger = GetComponent<AimScript>();
        trigger.Attack();
        StartCoroutine(Delay());

    }
}
