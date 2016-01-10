using UnityEngine;
using System.Collections;

public class NunBossDeathScript : MonoBehaviour {

    public void DeathTrigger()
    {
        LevelTimer.playerDead = false;
        AimScript.playerDead = false;

        CinematicMovmentScript.Cinematic = true;
        var start = GameObject.Find("CinematicController").GetComponent<CinematicMovmentScript>();
        start.startCinematic();

        var cloud = GameObject.FindGameObjectsWithTag("Cloud");
        var shots = GameObject.FindGameObjectsWithTag("Shot");
        var damage = GameObject.FindGameObjectsWithTag("Damage");

        for (int i = 0; i < shots.Length; i++)
        {
            Destroy(shots[i].gameObject);
        }

        for (int i = 0; i < damage.Length; i++)
        {
            Destroy(damage[i].gameObject);
        }

        for (int i = 0; i < cloud.Length; i++)
        {
            var script = cloud[i].GetComponent<DeathTimerScript>();
            script.delay();
        }

        StartCoroutine(selfKill());
    }

    IEnumerator selfKill()
    {
        yield return new WaitForSeconds(5f);
        var kill = GetComponent<DeathAnimationScript>();
        kill.AtDeath();

    }
}
