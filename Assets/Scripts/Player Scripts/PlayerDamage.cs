using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float health = 3f;
    public float immune = 0;
    public float abilityTime;
    int correctLayer;
    SpriteRenderer spriteRen;
    float immuneAnimeTimer = 0.2f;
    public int max_usage = 1;

    //for explosion effect
    public GameObject Explosion_effect;
    [SerializeField]
    private Transform attack_Point;


    //on collision
    void OnTriggerEnter2D()
    {
        print("Collided");

        if (immune <= 0)
        {
            health--;
            immune = 1f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();

        if (spriteRen == null)
        {
            Debug.Log("Error");
        }

        correctLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        // initiating special ability
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (max_usage > 0)
            {
                max_usage--;
                abilityTime = 5f;
                gameObject.layer = 8;
            }
        }

        abilityTime -= Time.deltaTime;
        immune -= Time.deltaTime;


        // Flashing Animation For Ability
        if (abilityTime <= 0)
        {
            gameObject.layer = correctLayer;

            if (spriteRen != null)
            {
                spriteRen.enabled = true;
            }
        }
        else
        {
            if (spriteRen != null)
            {
                immuneAnimeTimer -= Time.deltaTime;
                if (immuneAnimeTimer < 0)
                {
                    spriteRen.enabled = !spriteRen.enabled;
                    immuneAnimeTimer = 0.2f;
                }
            }
        }

        // Destroy Player
        if (health == 0)
        {
            Destroy(gameObject);
            Instantiate(Explosion_effect, attack_Point.position, Quaternion.identity);
        }
    }
}