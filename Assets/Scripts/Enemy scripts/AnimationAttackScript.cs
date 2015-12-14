using UnityEngine;
using System.Collections;

public class AnimationAttackScript : MonoBehaviour {


    public void AttackTrigger()
    {
        var Trigger = GetComponentInChildren<AimScript>();
        if (Trigger)
            Trigger.Attack();
    }
}
