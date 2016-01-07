using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public Animator anim;

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
    }

    public void Play()
    {
        var trigger = GetComponent<ActivatorScript>();
        trigger.Activate();
        anim.SetTrigger("Jump");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        print("Git chunging");
    }
}
