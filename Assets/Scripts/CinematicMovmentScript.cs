using UnityEngine;
using System.Collections;

public class CinematicMovmentScript : MonoBehaviour {

    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;

    public bool firstMovment = false;
    public bool secondMovment = false;
    public bool thirdMovment = false;
    public bool fourthMovment = false;

    public SpriteRenderer background;
    public SpriteRenderer background2;

    public GameObject Player;
    public GameObject fakePlayer;
    public GameObject Sister;
    public float speed;

    public GameObject EndGameMenu;

    public static bool Cinematic = false;

    public void startCinematic()
    {
        StartCoroutine(Movment());
    }

    void Update()
    {
        if (!Cinematic)
        {
            return;
        }

        
        float step = speed * Time.deltaTime;

        if (firstMovment && !secondMovment && !thirdMovment && !fourthMovment)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, target1.position, step);

        }
        else if(!firstMovment && secondMovment && !thirdMovment && !fourthMovment)
        {
            Sister.transform.position = Vector3.MoveTowards(Sister.transform.position, target2.position, step);
        }
        else if (!firstMovment && !secondMovment && thirdMovment && !fourthMovment)
        {
            fakePlayer.transform.position = Vector3.MoveTowards(fakePlayer.transform.position, target3.position, step);
        }
        if (!firstMovment && !secondMovment && !thirdMovment && fourthMovment)
        {
            Sister.transform.position = Vector3.MoveTowards(Sister.transform.position, target5.position, step);
            fakePlayer.transform.position = Vector3.MoveTowards(fakePlayer.transform.position, target4.position, step);
        }
    }

    IEnumerator Movment()
    {

        firstMovment = true;
        secondMovment = false;
        thirdMovment = false;
        fourthMovment = false;
        speed = 5;
        yield return new WaitForSeconds(6.7f);
        background2.color = background.color = new Color(0.90f, 0.90f, 0.90f, 0.90f);
        yield return new WaitForSeconds(0.25f);
        background2.color = background.color = new Color(0.80f, 0.80f, 0.80f, 0.80f);
        yield return new WaitForSeconds(0.25f);
        background2.color = background.color = new Color(0.70f, 0.70f, 0.70f, 0.70f);
        yield return new WaitForSeconds(0.25f);
        background2.color = background.color = new Color(0.60f, 0.60f, 0.60f, 0.60f);
        yield return new WaitForSeconds(0.25f);
        background2.color = background.color = new Color(0.50f, 0.50f, 0.50f, 0.50f);
        yield return new WaitForSeconds(0.25f);
        background2.color = background.color = new Color(0.40f, 0.40f, 0.40f, 0.40f);
        yield return new WaitForSeconds(0.25f);
        background2.color = background.color = new Color(0.30f, 0.30f, 0.30f, 0.30f);
        yield return new WaitForSeconds(0.25f);
        background2.color = background.color = new Color(0.20f, 0.20f, 0.20f, 0.20f);
        yield return new WaitForSeconds(0.25f);
        background2.color = background.color = new Color(0.10f, 0.10f, 0.10f, 0.10f);
        yield return new WaitForSeconds(2f);
        speed = 3;
        Player.SetActive(false);
        fakePlayer.SetActive(true);
        yield return new WaitForSeconds(2f);
        firstMovment = false;
        secondMovment = true;
        thirdMovment = false;
        fourthMovment = false;
        yield return new WaitForSeconds(4f);
        firstMovment = false;
        secondMovment = false;
        thirdMovment = true;
        fourthMovment = false;
        yield return new WaitForSeconds(4f);
        firstMovment = false;
        secondMovment = false;
        thirdMovment = false;
        fourthMovment = true;
        yield return new WaitForSeconds(6f);
        EndGameMenu.SetActive(true);
    }
}
