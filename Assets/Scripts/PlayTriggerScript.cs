using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayTriggerScript : MonoBehaviour {

    public void PlayTrigger()
    {
        SceneManager.LoadScene("Game");
    }
}
