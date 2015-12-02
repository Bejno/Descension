using UnityEngine;
using System.Collections;

public class SpriteRandomiser : MonoBehaviour {

    public SpriteRenderer ren;
    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        if (sprites.Length > 0)
            ren.sprite = sprites[Random.Range(0, sprites.Length)];
	}

    void OnValidate()
    {
        if (ren == null)
        {
            ren = GetComponent<SpriteRenderer>();
        }
    }
}
