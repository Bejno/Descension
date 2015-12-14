using UnityEngine;
using System.Collections;

public class ShotMovementScript : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public float deathTime;
    [Space]
    public SpriteRenderer sprite;
    [Range(0f,1f)]
    public float fromAlpha = 1f;
    [Range(0f,1f)]
    public float toAlpha = 0f;
    

    private float timePassed;

    void Start()
    {
        Destroy(gameObject, deathTime);
    }

    void Update()
    {

        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        movement *= Time.deltaTime;
        transform.position +=(movement);

        if (sprite != null)
        {
            timePassed += Time.deltaTime;
            float alpha = Mathf.Lerp(a: fromAlpha, b: toAlpha, t: timePassed / deathTime);

            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
        }
    }
}
