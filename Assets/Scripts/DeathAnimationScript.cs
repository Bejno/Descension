using UnityEngine;
using System.Collections;

public class DeathAnimationScript : MonoBehaviour {

    public GameObject partical;

    public void AtDeath () {

        Instantiate(partical, transform.position + partical.transform.localPosition, partical.transform.localRotation);
        Destroy(gameObject);

    }
}
