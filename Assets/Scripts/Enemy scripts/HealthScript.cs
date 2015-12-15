﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

    public float health, maxHealth;
    public float points;
    public bool miniBoss = false;
    public bool Boss = false;
    public GameObject deathParticle;
    //public GameObject NextWave;
    public NextWave wave;

    public void Damage () {

        health -= 1;

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

        Destroy(gameObject);
    }

    public enum NextWave
    {
        none, Wave2, Wave3
    }
}