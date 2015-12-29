using UnityEngine;
using System.Collections;

public class AttackDelayScript : MonoBehaviour {

    public float delay = 5;

	void Start () {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        var trigger = GetComponent<AimScript>();
        trigger.Attack();
    }

}
