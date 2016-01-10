using UnityEngine;
using System.Collections;

public class NunBossScript : MonoBehaviour {

    public GameObject Krucifix1;
    public GameObject Krucifix2;
    public GameObject NunSpawner;
    public float FireDelay = 1f;
    public float NextAttackDelay;
    public float currentAttack;

    public static bool alive = true;

    public float FireAttackRepeat = 3;

    void Start()
    {
        Krucifix();
    }

    delegate void AttackAction();
    void Randomiser()
    {
        // List of functions
        var attacks = new AttackAction[] {
            Krucifix, Krucifix, Krucifix, Nuns, Nuns, LaunchFire, LaunchFire, LaunchFire
        };

        // Take random function from the array
        int index = Random.Range(0, attacks.Length);
        var attack = attacks[index];
        // Call it
        attack();
    }

    void Krucifix()
    {
        if (alive)
        {
            Instantiate(Krucifix1, transform.position + Krucifix1.transform.localPosition, Krucifix1.transform.localRotation);
            Instantiate(Krucifix2, transform.position + Krucifix2.transform.localPosition, Krucifix2.transform.localRotation);
            NextAttackDelay = 6;
            StartCoroutine(AttackRandomiser(NextAttackDelay));
        }
        
    }

    void Nuns()
    {
        if (alive)
        {
            Instantiate(NunSpawner, transform.position + NunSpawner.transform.localPosition, NunSpawner.transform.localRotation);
            NextAttackDelay = 13;
            StartCoroutine(AttackRandomiser(NextAttackDelay));
        }
            
    }
        
    void LaunchFire()
    {
        if (alive)
            StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {

        
        foreach (var trigger in GetComponentsInChildren<AimScript>()) {
            if (alive)
                trigger.Attack();
        }

        FireAttackRepeat -= 1;
        yield return new WaitForSeconds(FireDelay);
        
        if(FireAttackRepeat > 0)
        {
            StartCoroutine(Fire());
        }
        else
        {
            FireAttackRepeat = 3;
            NextAttackDelay = 1;
            StartCoroutine(AttackRandomiser(NextAttackDelay));
        }
    }

    IEnumerator AttackRandomiser(float AttackDelay)
    {
        yield return new WaitForSeconds(AttackDelay);
        if (alive)
            Randomiser();
    }

}
