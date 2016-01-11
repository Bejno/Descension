using UnityEngine;
using System.Collections;

public class ShotBounceScript : MonoBehaviour {

    public float speed;

    public void BounceDown()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed, ForceMode2D.Impulse);
       //SoundManagerScript.PlayDonk();
    }

    public void BounceLeft()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed, ForceMode2D.Impulse);
        //SoundManagerScript.PlayDonk();
    }

    public void BounceRight()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        //SoundManagerScript.PlayDonk();
    }
}
