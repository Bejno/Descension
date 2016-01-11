using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public Animator anim;
    public GameObject buttons;

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        LevelTimer.playerDead = false;
        AimScript.playerDead = false;
        LevelTimer.PauseMenu = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        LevelTimer.playerDead = false;
        AimScript.playerDead = false;
        LevelTimer.PauseMenu = false;
        SoundManagerScript.PlayTypeWriterSound();
    }

    public void Play()
    {
        var trigger = GetComponent<ActivatorScript>();
        trigger.Activate();
        anim.SetTrigger("Jump");
        SoundManagerScript.PlayTypeWriterSound();
    }

    public void Exit()
    {
        Application.Quit();
        SoundManagerScript.PlayTypeWriterSound();
    }

    public void Options()
    {
        print("Git chunging");
        SoundManagerScript.PlayTypeWriterSound();
    }

    public void Resume()
    {
        LevelTimer.PauseMenu = false;
        buttons.SetActive(false);
        SoundManagerScript.PlayTypeWriterSound();
    }
}
