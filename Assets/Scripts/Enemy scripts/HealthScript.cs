using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public float health, maxHealth;
    public float points;
    public SpriteRenderer enemySprite;
    public bool miniBoss = false;
    public bool Boss = false;
    public bool NunBoss = false;
    public GameObject deathParticle;
    //public GameObject NextWave;
    public NextWave wave;
    public bool extraLife = false;
    public GameObject apple;


    public void Damage () {

        health -= 1;
        StartCoroutine(spriteFlash());

        if (health <= 0)
            Death();
	}

    void Death() {

        var score = FindObjectOfType<ScoreScript>();
        score.AddScore(points);

        if (miniBoss)  {
            var damage = FindObjectOfType<NextWaveScript>();
            damage.LosePoints();
        }

        if (NunBoss)
        {
            var bossScript = FindObjectOfType<NunBossDeathScript>();
            bossScript.DeathTrigger();
        }

        if (Boss)
        {
            var timer = GetComponentInParent<LevelTimer>();
            if (timer)
            {
                if (wave == NextWave.Wave2)
                    timer.Wave2();
            }
            else

                print("didnt find it...");
        }

            Instantiate(deathParticle, transform.position + deathParticle.transform.localPosition, deathParticle.transform.localRotation);

            var sound = GetComponent<SoundActivatorScript>();
            if(sound)
            sound.PlaySound();

        StartCoroutine(DeathDelay());
    }

    IEnumerator spriteFlash()
    {
        enemySprite.color = new Color(0.85f, 0, 0, 0.85f);
        yield return new WaitForSeconds(0.15f);
        enemySprite.color = new Color(1, 1, 1, 1);

    }

    IEnumerator DeathDelay()
    {

        yield return new WaitForSeconds(0.05f);

        if (!NunBoss)
        {
            Destroy(gameObject);
            if (extraLife)
            {
                Instantiate(apple, transform.position + apple.transform.localPosition, apple.transform.localRotation);
            }
        }
        else
        {
            PlayerScript.win = true;
            NunBossScript.alive = false;
        }
    }

    public enum NextWave
    {
        none, Wave2, Wave3
    }
}
