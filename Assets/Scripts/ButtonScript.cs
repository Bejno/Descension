using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        LevelTimer.playerDead = false;
        AimScript.playerDead = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
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
