using UnityEngine;
using System.Collections;

public class NunBossDeathScript : MonoBehaviour {

    public SpriteRenderer bell;
    public Animator anim;

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

        anim.SetTrigger("Burn");

        SoundManagerScript.PlayHolyBellSound();

        StartCoroutine(Bell());

        StartCoroutine(selfKill());
    }

    IEnumerator Bell()
    {
        bell.color = new Color(0.30f, 0.30f, 0.30f, 0.30f);
        yield return new WaitForSeconds(0.1f);
        bell.color = new Color(0.50f, 0.50f, 0.50f, 0.50f);
        yield return new WaitForSeconds(0.1f);
        bell.color = new Color(0.70f, 0.70f, 0.70f, 0.70f);
        yield return new WaitForSeconds(0.1f);
        bell.color = new Color(0.90f, 0.90f, 0.90f, 0.90f);
        yield return new WaitForSeconds(0.1f);
        bell.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.3f);
        bell.color = new Color(0.90f, 0.90f, 0.90f, 0.90f);
        yield return new WaitForSeconds(0.1f);
        bell.color = new Color(0.50f, 0.50f, 0.50f, 0.50f);
        yield return new WaitForSeconds(0.1f);
        bell.color = new Color(0.30f, 0.30f, 0.30f, 0.30f);
    }

    IEnumerator selfKill()
    {
        yield return new WaitForSeconds(5f);
        var kill = GetComponent<DeathAnimationScript>();
        kill.AtDeath();

    }
}
